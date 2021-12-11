import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NotesRoutingModule } from './notes-routing.module';
import { NoteMainComponent } from './components/note-main/note-main.component';
import { NoteSidebarComponent } from './components/note-sidebar/note-sidebar.component';
import { NoteEditorComponent } from './components/note-editor/note-editor.component';
import { NoteViewerComponent } from './components/note-viewer/note-viewer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/shared/material.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { TextEditorModule } from 'src/app/shared/text-editor.module';


@NgModule({
  declarations: [
    NoteMainComponent,
    NoteSidebarComponent,
    NoteEditorComponent,
    NoteViewerComponent
  ],
  imports: [
    CommonModule,
    NotesRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    TextEditorModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class NotesModule { }
