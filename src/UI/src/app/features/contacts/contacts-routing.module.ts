import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactHomeComponent } from './components/contact-home/contact-home.component';
import { ContactListComponent } from './components/contact-list/contact-list.component';

const routes: Routes = [
  {
    path:'',component: ContactHomeComponent,
    data: {
      breadcrumb: ''
    }
  },
  {
    path:'list',component: ContactListComponent,
    data: {
      breadcrumb: 'list'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContactsRoutingModule { }
