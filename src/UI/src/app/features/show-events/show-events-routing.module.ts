import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DisplayEventsComponent } from './components/display-events/display-events.component';

const routes: Routes = [
  {
    path:'',component: DisplayEventsComponent,
    data: {
      breadcrumb: ''
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShowEventsRoutingModule { }
