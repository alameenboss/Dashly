import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ContactsRoutingModule } from './contacts-routing.module';
import { ContactHomeComponent } from './components/contact-home/contact-home.component';
import { ContactSideBarComponent } from './components/contact-side-bar/contact-side-bar.component';
import { AddEditContactComponent } from './components/add-edit-contact/add-edit-contact.component';
import { ContactListComponent } from './components/contact-list/contact-list.component';


@NgModule({
  declarations: [
    ContactHomeComponent,
    ContactSideBarComponent,
    AddEditContactComponent,
    ContactListComponent
  ],
  imports: [
    CommonModule,
    ContactsRoutingModule
  ]
})
export class ContactsModule { }
