import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Webapp } from '../models/Webapp.model';

@Injectable({
  providedIn: 'root'
})
export class WebappService {
  webappUrl: string = environment.apiUrl + '/' + 'webapp'
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Webapp[]>(this.webappUrl);
  }

  getById(id: number) {
    return this.http.get<Webapp>(this.webappUrl + '/' + id);
  }
  insert(request: any) {
    return this.http.post<Webapp>(this.webappUrl, request);
  }
  update(id: number, request: any) {
    return this.http.put<Webapp>(this.webappUrl + '/' + id, request);
  }
  delete(id: number) {
    return this.http.delete<any>(this.webappUrl + '/' + id);
  }
  deleteAll() {
    return this.http.delete<any>(this.webappUrl);
  }
  
  addAtachment(webAppId: number, fileUrl: string) {
    return this.http.post<any>(`${this.webappUrl}/${webAppId}/addatachment`, {
      name: fileUrl,
      type: 'Full'
    });
  }
}
