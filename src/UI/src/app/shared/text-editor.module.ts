import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TextEditorComponent } from './components/text-editor/quill/text-editor.component';
import { ReactiveFormsModule } from '@angular/forms';
import { QuillModule } from 'ngx-quill';
import { MarkdownEditorComponent } from './components/text-editor/markdown-editor/markdown-editor.component';
import { TextFieldModule } from '@angular/cdk/text-field';

@NgModule({
  declarations: [
    TextEditorComponent,
    MarkdownEditorComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    QuillModule,
    TextFieldModule
  ],
  exports: [
    TextEditorComponent,
    MarkdownEditorComponent
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class TextEditorModule { }
