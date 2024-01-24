import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FileExplorerRoutingModule } from './file-explorer-routing.module';
import { FileExplorerComponent } from './components/file-explorer/file-explorer.component';
import { RenameDialogComponent } from './components/rename-dialog/rename-dialog.component';
import { NewFolderDialogComponent } from './components/new-folder-dialog/new-folder-dialog.component';
import { FileExplorerMainComponent } from './components/file-explorer-main/file-explorer-main.component';
import { MaterialModule } from 'src/app/shared/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    FileExplorerComponent,
    RenameDialogComponent,
    NewFolderDialogComponent,
    FileExplorerMainComponent
  ],
  imports: [
    CommonModule,
    FileExplorerRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class FileExplorerModule { }
