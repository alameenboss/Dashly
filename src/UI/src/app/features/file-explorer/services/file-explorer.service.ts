import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { v4 } from 'uuid';

@Injectable({
  providedIn: 'root'
})
export class FileExplorerService {
  private querySubject: BehaviorSubject<FileElement[]>;
  private map = new Map<string, FileElement>();
  private filesUrl: string = environment.apiUrl + '/' + 'files';
  constructor(private http: HttpClient) {}

  add(fileElement: FileElement) {
    fileElement.id = v4();
    this.map.set(fileElement.id, this.clone(fileElement));
    return fileElement;
  }

  delete(id: string) {
    this.map.delete(id);
  }

  update(id: string, update: Partial<FileElement>) {
    let element = this.map.get(id);
    element = Object.assign(element, update);
    this.map.set(element.id, element);
  }

  clear(){
    this.map = new Map<string, FileElement>()
    this.querySubject.next(null);
  }
  
  queryInFolder(folderId: string) {
    const result: FileElement[] = [];
    this.map.forEach(element => {
      if (element.parent === folderId) {
        result.push(this.clone(element));
      }
    });
    if (!this.querySubject) {
      this.querySubject = new BehaviorSubject(result);
    } else {
      this.querySubject.next(result);
    }
    return this.querySubject.asObservable();
  }

  get(id: string) {
    return this.map.get(id);
  }

  clone(element: FileElement) {
    return JSON.parse(JSON.stringify(element));
  }

  getRootDirectories() {
    return this.http.get(this.filesUrl+'/getdrives');
  }

  getFiles(path:string){
    return this.http.get(this.filesUrl+'/GetFiles?path='+path);
  }
}


export interface IFileService {
  add(fileElement: FileElement);
  delete(id: string);
  update(id: string, update: Partial<FileElement>);
  queryInFolder(folderId: string): Observable<FileElement[]>;
  get(id: string): FileElement;
}

export class FileElement {
  id?: string;
  itemType: string;
  name: string;
  parent: string;
}