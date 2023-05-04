import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ImpoterComponent } from './features/import-data/impoter/impoter.component';
import { SignInComponent } from './features/integration/components/signin/signin.component';
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
    path: 'projects',
    component: MainNavComponent,
    data: {
      breadcrumb: 'Projects'
    },
    loadChildren: () => import('src/app/features/projects/projects.module').then(m => m.ProjectsModule)
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
    path: 'documents',
    data: {
      breadcrumb: 'Document'
    },
    component: MainNavComponent,
    loadChildren: () => import('src/app/features/documents/documents.module').then(m => m.DocumentsModule)
  },
  {
    path: 'contacts',
    data: {
      breadcrumb: 'Contact'
    },
    component: MainNavComponent,
    loadChildren: () => import('src/app/features/contacts/contacts.module').then(m => m.ContactsModule)
  },
  {
    path: 'showevents',
    data: {
      breadcrumb: 'Show Events'
    },
    component: MainNavComponent,
    loadChildren: () => import('src/app/features/show-events/show-events.module').then(m => m.ShowEventsModule)
  },
  {
    path: 'authentication',
    loadChildren: () => import('src/app/features/authentication/authentication.module').then(m => m.AuthenticationModule)
  },
  {
    path: 'integration',
    data: {
      breadcrumb: 'Integration'
    },
    component: MainNavComponent,
    loadChildren: () => import('src/app/features/integration/integration.module').then(m => m.IntegrationModule)
  },
  {
    path: 'task',
    data: {
      breadcrumb: 'Task'
    },    
    component: MainNavComponent,
    loadChildren: () => import('src/app/features/task-board/task-board.module').then(m => m.TaskBoardModule)
  },
  {
    path: 'video-player',
    data: {
      breadcrumb: 'video-player'
    },    
    component: MainNavComponent,
    loadChildren: () => import('src/app/features/video-player/video-player.module').then(m => m.VideoPlayerModule)
  },
  {
    path: 'oauth/signin', component: SignInComponent
  },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
