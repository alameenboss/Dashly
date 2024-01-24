import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {

  constructor(private http:HttpClient) {
    
    
  }
  uploadfile(file: any) {
    //uploadfile(files: any[]) {
   
    const formData = new FormData();
    formData.append('file', file, file.name);
    // Array.from(files).map((file, index) => {
    //   return formData.append('file'+index, file, file.name);
    // });

    let url =`${environment.apiUrl}/fileupload`
    return this.http.post(url,formData,{reportProgress: true, observe: 'events'})

    
  }

}
