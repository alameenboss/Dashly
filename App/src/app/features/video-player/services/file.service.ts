import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { FileFolder } from '../models/FileFolder';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  fileUrl: string = environment.apiUrl + '/' + 'files'
  constructor(private http: HttpClient) { }

  getDrives() {
    return this.http.get<string[]>(this.fileUrl + '/' + 'GetDrives');
  }

  getFiles(path: string) {

    return this.http.get<FileFolder>(this.fileUrl + '/' + 'GetFiles' + '?path=' + path);
  }

}