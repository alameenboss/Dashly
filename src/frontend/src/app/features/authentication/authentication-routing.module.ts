import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  {
    path: '', component: LoginComponent,
    data: {
      breadcrumb: ''
    },
    children: [
      {
        path: 'home', component: HomeComponent,
        data: {
          breadcrumb: 'Home'
        }
      },
      {
        path: 'login', component: LoginComponent,
        data: {
          breadcrumb: 'Login'
        }
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthenticationRoutingModule { }
