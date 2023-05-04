import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShowEventsRoutingModule } from './show-events-routing.module';
import { DisplayEventsComponent } from './components/display-events/display-events.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/shared/material.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { FlatpickrModule } from 'angularx-flatpickr';
import { NgxCsvParserModule } from 'ngx-csv-parser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
@NgModule({
  declarations: [
    DisplayEventsComponent
  ],
  imports: [
    NgbModule,
    NgxCsvParserModule,
    FlatpickrModule.forRoot(),
    CalendarModule.forRoot({ provide: DateAdapter, useFactory: adapterFactory }),
    CommonModule,
    ShowEventsRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class ShowEventsModule { }
