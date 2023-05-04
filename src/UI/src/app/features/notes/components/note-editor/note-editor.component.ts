import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { Subscription } from 'rxjs';
import { Note } from '../../models/note.model';
import { NotesService } from '../../services/notes.service';
import { CommonService } from "../../services/CommonService";

@Component({
  selector: 'app-note-editor',
  templateUrl: './note-editor.component.html',
  styleUrls: ['./note-editor.component.scss']
})
export class NoteEditorComponent implements OnInit, OnDestroy {
  noteForm: FormGroup;
  note: Note;
  noteId: number;
  categoryId: any;
  routeSub: Subscription;
  editMode: boolean = false;

  constructor(private _fb: FormBuilder,
    public commonService: CommonService,
    public notesService: NotesService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.noteForm = this._fb.group({
      title: [null, Validators.required],
      notes: [],
      noteCategoryId: null,
    });
    this.routeSub = this.route.params.subscribe((param: Params) => {

      if (param['id'] != undefined) {
        this.noteId = param['id'];
      }

      if (param['categoryId'] != undefined) {
        this.noteId = 0;
        this.categoryId = param['categoryId'];
      }

      if (this.noteId > 0) {
        this.editMode = true;
        this.getNoteById(this.noteId);
      }

    })
  }

  get notesRawControl() {
    return this.noteForm.controls['notes'] as FormControl;
  }

  getNoteById(id: number): any {

    this.notesService.getById(id).subscribe((noteRes: Note) => {
      this.note = noteRes;
      this.noteForm.patchValue({
        title: this.note.title,
        notes: this.note.notes,
        noteCategoryId: this.note.noteCategoryId,
      })
    })

  }
  onSubmit() {
    if (this.editMode) {
      this.notesService
        .update(this.noteId, this.noteForm.value)
        .subscribe((res: boolean) => {
          this.commonService.sendUpdate('Note Updated');
        });
    } else {
      let newNote: Note = {
        title: this.noteForm.value.title,
        notes: this.noteForm.value.notes,
        noteCategoryId: this.categoryId
      }
      this.notesService
        .insert(newNote)
        .subscribe((res: number) => {
          this.commonService.sendUpdate('Note Added');
        });
    }

  }

  ngOnDestroy(): void {
    this.routeSub.unsubscribe();
  }
}
