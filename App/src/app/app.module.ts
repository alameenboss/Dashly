import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './shared/material.module';
import { SharedModule } from './shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthenticationModule } from './features/authentication/authentication.module';
import { WebappModule } from './features/webapps/webapp.module';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { HomeComponent } from './pages/home/home.component';
import { ImpoterComponent } from './features/import-data/impoter/impoter.component';
import { QuillModule } from 'ngx-quill';
import { SignInComponent } from './integration/components/signin/signin.component';

const applicationModule = [
  AuthenticationModule,
  WebappModule
]

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    HomeComponent,
    ImpoterComponent,
    SignInComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    SharedModule,
    QuillModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
