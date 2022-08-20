import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FeedbackMainComponent } from './components/feedback-main/feedback-main.component';

const routes: Routes = [
  {
    path: '',
    component: FeedbackMainComponent,
    data: {
      breadcrumb: ''
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeedbackRoutingModule { }
