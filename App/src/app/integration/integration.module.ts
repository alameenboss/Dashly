import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IntegrationRoutingModule } from './integration-routing.module';
import { ListIntegrationComponent } from './components/list-integration/list-integration.component';
import { AddEditIntegrationComponent } from './components/add-edit-integration/add-edit-integration.component';
import { MaterialModule } from '../shared/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    AddEditIntegrationComponent,
    ListIntegrationComponent
  ],
  imports: [
    CommonModule, 
    IntegrationRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class IntegrationModule { }
