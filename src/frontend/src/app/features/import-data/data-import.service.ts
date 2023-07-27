import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DataImportService {

  importdataUrl: string = environment.apiUrl + '/' + 'importdata'
  constructor(private http: HttpClient) { }

  import(type,file:File) {
    let fd = new FormData();
    fd.append("file",file,file.name);
    return this.http.put<any>(`${this.importdataUrl}/${type}`,fd,{reportProgress: true, observe: 'events'});
  }

}
