import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/shared/material.module';
import { ConfiramtionComponent } from './components/confiramtion/confiramtion.component';
import { MainNavComponent } from './components/layout/main-nav/main-nav.component';
import { SpinnerOverlayComponent } from './components/spinner-overlay/spinner-overlay.component';
import { DndDirective } from './directives/dnd.directive';
import { ProgressComponent } from './components/progress/progress.component';
import { FileuploadComponent } from './components/fileupload/fileupload.component';
import { RouterModule } from '@angular/router';
import { MenuListItemComponent } from './components/layout/menu-list-item/menu-list-item.component';
import { BreadcrumbComponent } from './components/layout/breadcrumb/breadcrumb.component';

const directive = [
  DndDirective,
]
const components = [
  ConfiramtionComponent,
  SpinnerOverlayComponent,
  MainNavComponent,
  MenuListItemComponent,
  BreadcrumbComponent,
  ProgressComponent,
  FileuploadComponent
]
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    RouterModule
  ],
  declarations: [
    ...directive,
    ...components,

  ],
  exports: [
    ...directive,
    ...components,
  ]
})
export class SharedModule { }
