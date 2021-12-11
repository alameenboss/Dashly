import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthenticationService } from 'src/app/features/authentication/services/authentication.service';

@Injectable()
export class ApiKeyInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add auth header with jwt if user is logged in and request is to api url
        const isApiUrl = request.url.startsWith(environment.apiUrl);
        if (isApiUrl) {
            request = request.clone({
                setHeaders: {
                    ApiKey: `${environment.apikey}`
                }
            });
        }

        return next.handle(request);
    }
}