import { Component, OnInit } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-board-list',
  templateUrl: './board-list.component.html',
  styleUrls: ['./board-list.component.scss']
})
export class BoardListComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  status = [
    { name: "To do", data: ['Get to work', 'Pick up groceries', 'Go home', 'Fall asleep'] },
    { name: 'In Progress', data: ['Get up', 'Brush teeth', 'Take a shower', 'Check e-mail'] },
    { name: 'Review', data: [] },
    { name: 'Pending', data: [] },
    { name: 'Won\'t Do', data: [] },
    { name: 'Done', data: ['Walk dog'] }
  ]

  drop(event: CdkDragDrop<string[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
    }
  }
}
