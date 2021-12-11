import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditWebappComponent } from './components/add-edit-webapp/add-edit-webapp.component';
import { CardViewComponent } from './components/card-view/card-view.component';
import { ListViewComponent } from './components/list-view/list-view.component';

const routes: Routes = [
  { path: '', component: ListViewComponent },
  { path: 'cardview', component: CardViewComponent },
  { path: 'listview', component: ListViewComponent },
  { path: 'add', component: AddEditWebappComponent},
  { path: 'edit/:id', component: AddEditWebappComponent}
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WebappRoutingModule { }
