import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/shared/material.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { FeedbackMainComponent } from './components/feedback-main/feedback-main.component';
import { FeedbackRoutingModule } from './feedback-routing.module';



@NgModule({
  declarations: [
    FeedbackMainComponent
  ],
  imports: [
    CommonModule,
    FeedbackRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class FeedbackModule { }
