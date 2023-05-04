import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PhoneCallsService {

  phoneCallsUrl: string = environment.apiUrl + '/' + 'phonecalls'
  
  constructor(private http: HttpClient) { }

  scan() {
    return this.http.post<any>(`${this.phoneCallsUrl}/scan`,{});
  }
}
