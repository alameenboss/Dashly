import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditIntegrationComponent } from './components/add-edit-integration/add-edit-integration.component';
import { ListIntegrationComponent } from './components/list-integration/list-integration.component';

const routes: Routes = [
  { path: '', component: ListIntegrationComponent },
  { path: 'list', component: ListIntegrationComponent },
  { path: 'add', component: AddEditIntegrationComponent},
  { path: 'edit/:id', component: AddEditIntegrationComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IntegrationRoutingModule { }
