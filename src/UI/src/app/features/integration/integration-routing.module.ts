import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditIntegrationComponent } from './components/add-edit-integration/add-edit-integration.component';
import { ListIntegrationComponent } from './components/list-integration/list-integration.component';

const routes: Routes = [
  {
    path: '',
    component: ListIntegrationComponent,
    data: {
      breadcrumb: 'List'
    }
  },
  {
    path: 'list',
    component: ListIntegrationComponent,
    data: {
      breadcrumb: 'List'
    }
  },
  {
    path: 'add',
    component: AddEditIntegrationComponent,
    data: {
      breadcrumb: 'Add'
    }
  },
  {
    path: 'edit/:id',
    component: AddEditIntegrationComponent,
    data: {
      breadcrumb: 'Edit'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IntegrationRoutingModule { }
