import { Injectable, Injector } from '@angular/core';
import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppSettings } from '../app.settings';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

    constructor()
    { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {   
        let token = localStorage.getItem(AppSettings.AUTH_KEY);

        if (token){
            console.log("Token is found");
            req = req.clone({
                setHeaders: {
                    Authorization: "Bearer " + token
                }
            });
        };

        return next.handle(req);
    }
}
