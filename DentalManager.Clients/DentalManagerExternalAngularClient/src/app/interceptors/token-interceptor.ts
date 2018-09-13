import { Injectable, Injector } from '@angular/core';
import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
    HttpResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { AppSettings } from '../app.settings';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

    constructor(){
        console.log("TokenInterceptor");
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        req = req.clone({
            setHeaders: {
                Authorization: `Bearer ${localStorage.getItem(AppSettings.AUTH_KEY)}`
            }
        });

        return next.handle(req)
            .pipe(
                tap(res => {
                    if (res instanceof HttpResponse) {
                        this.saveToken(res.body.token);
                    }
                }, error => {
                    // http response status code
                    console.log("----response----");
                    console.error(error);
                })
            )
    }

    private saveToken(token){
        localStorage.setItem(AppSettings.AUTH_KEY, token);
    }
}
