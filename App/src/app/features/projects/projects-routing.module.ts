import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CardViewComponent } from './components/card-view/card-view.component';
import { TableViewComponent } from './components/table-view/table-view.component';

const routes: Routes = [
  {
    path: '', component: TableViewComponent,
    data: {
      breadcrumb: 'List'
    }
  },
  {
    path: 'cardview', component: CardViewComponent,
    data: {
      breadcrumb: 'Card'
    }
  },
  {
    path: 'listview', component: TableViewComponent,
    data: {
      breadcrumb: 'List'
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjectsRoutingModule { }
