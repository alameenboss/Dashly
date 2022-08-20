import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VideoPlayerRoutingModule } from './video-player-routing.module';

import { VgCoreModule } from '@videogular/ngx-videogular/core';
import { VgControlsModule } from '@videogular/ngx-videogular/controls';
import { VgOverlayPlayModule } from '@videogular/ngx-videogular/overlay-play';
import { VgBufferingModule } from '@videogular/ngx-videogular/buffering';

import { VideoPlayerComponent } from './components/video-player/video-player.component';
import { VdoPlayerComponent } from './components/vdo-player/vdo-player.component';
import { PlayListsComponent } from './components/play-lists/play-lists.component';

@NgModule({
  declarations: [
    VideoPlayerComponent,
    VdoPlayerComponent,
    PlayListsComponent
  ],
  imports: [
    CommonModule,
    VideoPlayerRoutingModule,
    VgCoreModule,
    VgControlsModule,
    VgOverlayPlayModule,
    VgBufferingModule
  ]
})
export class VideoPlayerModule { }
