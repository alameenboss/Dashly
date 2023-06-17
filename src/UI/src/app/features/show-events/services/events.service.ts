import { Injectable } from '@angular/core';
import { CalendarEvent } from 'calendar-utils';

@Injectable({
  providedIn: 'root'
})
export class EventsService {

  constructor() { }

  getEvents(): CalendarEvent[] {
    return [
      {
        start: new Date(2023, 6, 17, 19, 53, 35),
        title: 'Alameen-9876543210',
      },
      {
        start: new Date(2023, 6, 17, 19, 56, 28),
        title: 'Alameen-9876543210',
      }
    ]
  }

  callList = `
  Call@Alameen(00919876543210)_20230617190914.mp3,
  Call@Alameen(00919876543210)_20230617080029.mp3`
}
