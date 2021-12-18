import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NoteEditorComponent } from './components/note-editor/note-editor.component';
import { NoteMainComponent } from './components/note-main/note-main.component';
import { NoteViewerComponent } from './components/note-viewer/note-viewer.component';

const routes: Routes = [
  {
    path: '',
    component: NoteMainComponent,
    data: {
      breadcrumb: ''
    },
    children: [
      {
        path: ':categoryId/add',
        component: NoteEditorComponent,
        data: {
          breadcrumb: 'Add Category'
        },
      },
      {
        path: 'edit/:id',
        component: NoteEditorComponent,
        data: {
          breadcrumb: 'Edit'
        },
      },
      {
        path: 'view/:id',
        component: NoteViewerComponent,
        data: {
          breadcrumb: 'View'
        },
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NotesRoutingModule { }
