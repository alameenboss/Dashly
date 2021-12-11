import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FeedbackMainComponent } from './features/feedbacks/components/feedback-main/feedback-main.component';
import { ImpoterComponent } from './features/import-data/impoter/impoter.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { HomeComponent } from './pages/home/home.component';
import { MainNavComponent } from './shared/components/layout/main-nav/main-nav.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'dashboard',
    component: MainNavComponent,
    children: [
      { path: '', component: DashboardComponent, pathMatch: 'full' },
      { path: 'import', component: ImpoterComponent, pathMatch: 'full' }
    ]
  },
  {
    path: 'webapp',
    component: MainNavComponent,
    loadChildren: () => import('src/app/features/webapps/webapp.module').then(m => m.WebappModule)
  },
  {
    path: 'fileexplorer',
    component: MainNavComponent,
    loadChildren: () => import('src/app/features/file-explorer/file-explorer.module').then(m => m.FileExplorerModule)
  },
  {
    path: 'github',
    component: MainNavComponent,
    loadChildren: () => import('src/app/features/Github/github.module').then(m => m.GithubModule)
  },
  {
    path: 'notes',
    component: MainNavComponent,
    loadChildren: () => import('src/app/features/notes/notes.module').then(m => m.NotesModule)
  },
  {
    path: 'documents',
    component: MainNavComponent,
    loadChildren: () => import('src/app/features/documents/documents.module').then(m => m.DocumentsModule)
  },
  {
    path: 'feedback',
    component: MainNavComponent,
    loadChildren: () => import('src/app/features/feedbacks/feedback.module').then(m => m.FeedbackModule)
  },
  {
    path: 'authentication',
    loadChildren: () => import('src/app/features/authentication/authentication.module').then(m => m.AuthenticationModule)
  },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
