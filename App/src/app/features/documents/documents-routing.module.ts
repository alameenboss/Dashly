import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { v4 as uuidV4 } from "uuid";
import { DocEditorComponent } from './components/doc-editor/doc-editor.component';
import { DocumentListComponent } from './components/document-list/document-list.component';

const routes: Routes = [
  {
    path: '', redirectTo:`edit/${uuidV4()}`,pathMatch: 'full',
    data: {
      breadcrumb: ''
    }
  },
  {
    path:'',component: DocEditorComponent,
    data: {
      breadcrumb: ''
    }
  },
  {
    path:'list',component: DocumentListComponent,
    data: {
      breadcrumb: 'list'
    }
  },
  {
    path: 'edit/:id', component: DocEditorComponent,
    data: {
      breadcrumb: 'Edit'
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DocumentsRoutingModule { }
