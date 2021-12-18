import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TaskBoardRoutingModule } from './task-board-routing.module';
import { AddEditBoardComponent } from './components/add-edit-board/add-edit-board.component';
import { AddBoardColumnsComponent } from './components/add-board-columns/add-board-columns.component';
import { BoardCardsComponent } from './components/board-cards/board-cards.component';
import { BoardListComponent } from './components/board-list/board-list.component';
import { DragDropModule } from '@angular/cdk/drag-drop';


@NgModule({
  declarations: [
    AddEditBoardComponent,
    AddBoardColumnsComponent,
    BoardCardsComponent,
    BoardListComponent
  ],
  imports: [
    CommonModule,
    TaskBoardRoutingModule,
    DragDropModule,
  ]
})
export class TaskBoardModule { }
