import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DocumentsRoutingModule } from './documents-routing.module';
import { DocEditorComponent } from './components/doc-editor/doc-editor.component';
import { TextEditorModule } from 'src/app/shared/text-editor.module';
import { DocumentListComponent } from './components/document-list/document-list.component';
import { MaterialModule } from 'src/app/shared/material.module';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    DocEditorComponent,
    DocumentListComponent
  ],
  imports: [
    CommonModule,
    TextEditorModule,
    MaterialModule,
    ReactiveFormsModule,
    DocumentsRoutingModule
  ],
})
export class DocumentsModule { }
