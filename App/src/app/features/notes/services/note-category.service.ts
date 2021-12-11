import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { NoteCategory } from '../models/note-category.model';

@Injectable({
  providedIn: 'root'
})
export class NoteCategoryService {

  noteCategoryUrl: string = environment.apiUrl + '/' + 'notecategory'
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<NoteCategory[]>(this.noteCategoryUrl);
  }
  
  getById(id: number) {
    return this.http.get<NoteCategory>(this.noteCategoryUrl + '/' + id);
  }
  insert(request: NoteCategory) {
    return this.http.post<number>(this.noteCategoryUrl, request);
  }
  update(id: number, request: NoteCategory) {
    return this.http.put<boolean>(this.noteCategoryUrl + '/' + id, request);
  }
  delete(id: number) {
    return this.http.delete<boolean>(this.noteCategoryUrl + '/' + id);
  }
  deleteAll() {
    return this.http.delete<boolean>(this.noteCategoryUrl);
  }
}
