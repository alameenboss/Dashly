import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticationRoutingModule } from './authentication-routing.module';
import { LoginComponent } from './components/login/login.component';
import { MaterialModule } from 'src/app/shared/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './components/home/home.component';


@NgModule({
  declarations: [LoginComponent, HomeComponent],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    LoginComponent
  ]
})
export class AuthenticationModule { }
