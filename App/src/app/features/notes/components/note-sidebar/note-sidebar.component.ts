import { FlatTreeControl } from '@angular/cdk/tree';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { NoteCategory } from '../../models/note-category.model';
import { Note } from '../../models/note.model';
import { NoteCategoryService } from '../../services/note-category.service';
import { CommonService } from "../../services/CommonService";
import { NotesService } from '../../services/notes.service';

@Component({
  selector: 'app-note-sidebar',
  templateUrl: './note-sidebar.component.html',
  styleUrls: ['./note-sidebar.component.scss']
})
export class NoteSidebarComponent implements OnInit, OnDestroy {

  messageReceived: any;
  private subscriptionName: Subscription;

  constructor(
    public noteCategoryService: NoteCategoryService,
    public notesService: NotesService,
    public commonService: CommonService,
    public router: Router,
    private route: ActivatedRoute
  ) {

    this.subscriptionName = this.commonService.getUpdate().subscribe(message => {
      this.messageReceived = message;
      this.getLatestNotes();
    });
  }

  notecategories: NoteCategory[];

  ngOnInit(): void {
    
    this.getLatestNotes();
  }

  getLatestNotes(){
    this.noteCategoryService.getAll().subscribe(categories => {
      this.notecategories = categories;
    })
  }

  
  onCategorySelected(category: NoteCategory) {
    this.router.navigate([category.id, 'add'], { relativeTo: this.route });
  }

  deleteNote(note: Note) {
    this.notesService.delete(note.id).subscribe(x=>{
      this.commonService.sendUpdate('Note Updated');
    })
  }

  onNoteSelected(note: Note) {
    this.router.navigate(['view', note.id], { relativeTo: this.route });
  }
  editNote(note: Note) {
    this.router.navigate(['edit', note.id], { relativeTo: this.route });
  }


  ngOnDestroy() {
    this.subscriptionName.unsubscribe();
  }
}
