import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlayListsComponent } from './components/play-lists/play-lists.component';
import { VdoPlayerComponent } from './components/vdo-player/vdo-player.component';
import { VideoPlayerComponent } from './components/video-player/video-player.component';

const routes: Routes = [
  {
    path: '',
    component: PlayListsComponent,
    data: {
      breadcrumb: ''
    },
    children: [
      {
        path: ':id',
        component: VideoPlayerComponent,
        data: {
          breadcrumb: 'Video Player'
        },
      },
      {
        path: 'play-list',
        component: PlayListsComponent,
        data: {
          breadcrumb: 'Play Lists'
        },
      },
      {
        path: 'play-list/:id',
        component: VdoPlayerComponent,
        data: {
          breadcrumb: 'Play Lists'
        },
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VideoPlayerRoutingModule { }
