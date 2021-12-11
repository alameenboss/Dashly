import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NoteEditorComponent } from './components/note-editor/note-editor.component';
import { NoteMainComponent } from './components/note-main/note-main.component';
import { NoteViewerComponent } from './components/note-viewer/note-viewer.component';

const routes: Routes = [
  {
    path: '',
    component: NoteMainComponent,
    children: [
      {
        path: ':categoryId/add',
        component: NoteEditorComponent,
      },
      {
        path: 'edit/:id',
        component: NoteEditorComponent,
      },
      {
        path: 'view/:id',
        component: NoteViewerComponent,
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NotesRoutingModule { }
