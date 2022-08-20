import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WebappRoutingModule } from './webapp-routing.module';
import { CardComponent } from './components/card/card.component';
import { CardViewComponent } from './components/card-view/card-view.component';
import { ListViewComponent } from './components/list-view/list-view.component';
import { MaterialModule } from 'src/app/shared/material.module';
import { AddEditWebappComponent } from './components/add-edit-webapp/add-edit-webapp.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { WebappDefaultComponent } from './components/webapp-default/webapp-default.component';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [
    ListViewComponent, 
    CardViewComponent, 
    CardComponent,
    AddEditWebappComponent,
    WebappDefaultComponent
  ],
  imports: [
    CommonModule,
    WebappRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class WebappModule { }
