import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationBehaviorOptions, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Note } from '../../models/note.model';
import { NotesService } from '../../services/notes.service';
@Component({
  selector: 'app-note-viewer',
  templateUrl: './note-viewer.component.html',
  styleUrls: ['./note-viewer.component.scss']
})
export class NoteViewerComponent implements OnInit,OnDestroy {
  note: Note;
  noteId: number;
  routeSub: Subscription;

  constructor(
    public notesService: NotesService,
    public router: Router,
    private route: ActivatedRoute) { }
 

  ngOnInit(): void {
   this.routeSub =  this.route.params.subscribe(param => {
      this.noteId = param.id;
      this.getNoteById(param.id);
    })
  }

  getNoteById(id: number): any {
    this.notesService.getById(id).subscribe((noteRes: Note) => {
      this.note = noteRes;
    })
  }
  ngOnDestroy(): void {
    this.routeSub.unsubscribe();
  }
  
  onEditClick(){

    this.router.navigate(['../../edit',this.noteId],{ relativeTo: this.route });
  }

}
