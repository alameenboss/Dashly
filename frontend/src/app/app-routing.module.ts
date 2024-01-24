import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ImpoterComponent } from './features/import-data/impoter/impoter.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { HomeComponent } from './pages/home/home.component';
import { MainNavComponent } from './pages/layout/main-nav/main-nav.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'dashboard',
    component: MainNavComponent,
    data: {
      breadcrumb: 'Dashboard'
    },
    children: [
      {
        path: '', 
        component: DashboardComponent,
        data: {
          breadcrumb: ''
        }, 
        pathMatch: 'full'
      },
      {
        path: 'import', 
        component: ImpoterComponent,
        data: {
          breadcrumb: 'Import'
        }, 
        pathMatch: 'full'
      }
    ]
  },
  {
    path: 'webapp',
    component: MainNavComponent,
    data: {
      breadcrumb: 'Webapp'
    },
    loadChildren: () => import('src/app/features/webapps/webapp.module').then(m => m.WebappModule)
  },
  {
    path: 'fileexplorer',
    component: MainNavComponent,
    data: {
      breadcrumb: 'File Explorer'
    },
    loadChildren: () => import('src/app/features/file-explorer/file-explorer.module').then(m => m.FileExplorerModule)
  },
  {
    path: 'notes',
    data: {
      breadcrumb: 'Notes'
    },
    component: MainNavComponent,
    loadChildren: () => import('src/app/features/notes/notes.module').then(m => m.NotesModule)
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
