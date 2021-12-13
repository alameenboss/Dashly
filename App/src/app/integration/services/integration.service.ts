import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Integration } from '../models/Integration.model';

@Injectable({
  providedIn: 'root'
})
export class IntegrationService {
  

  integrationUrl: string = environment.apiUrl + '/' + 'oauthintegration';

  constructor(private http: HttpClient) { }

  getAll(){
    return this.http.get(`${this.integrationUrl}`);
  }

  getOAuthClientIdByName(appName: string) {
    return this.http.get(`${this.integrationUrl}/getclientid/${appName}`);
  }

  updateOAuthCode(appName: string, code: any) {
    return this.http.put<boolean>(`${this.integrationUrl}/${appName}`,{
      code : code
    });
  }
  deleteAll() {
    return of<Integration>();
  }
  delete(id: number) {
    return of<Integration>();
  }
}
