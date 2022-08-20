import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Note } from '../models/note.model';

@Injectable({
  providedIn: 'root'
})
export class NotesService {

  notesUrl: string = environment.apiUrl + '/' + 'notes'
  constructor(private http: HttpClient) { }

  getById(id: number) {
    return this.http.get<Note>(this.notesUrl + '/' + id);
  }
  getByCategory(categoryId: number) {
    return this.http.get<Note[]>(this.notesUrl + '/category/' + categoryId);
  }
  insert(request: Note) {
    return this.http.post<number>(this.notesUrl, request);
  }
  update(id: number, request: Note) {
    return this.http.put<boolean>(this.notesUrl + '/' + id, request);
  }
  delete(id: number) {
    return this.http.delete<boolean>(this.notesUrl + '/' + id);
  }
  deleteByCategory(categoryId: number) {
    return this.http.delete<boolean>(this.notesUrl + '/category/' + categoryId);
  }
  deleteAll() {
    return this.http.delete<boolean>(this.notesUrl);
  }
}