import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { LoginModel } from '../models/LoginModel';
import { AppSettings } from '../../app.settings';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private authToken : string;

  get token() : string{
    return this.authToken;
  }

  set token(authToken : string){
    this.authToken = authToken;
    localStorage.setItem(AppSettings.AUTH_KEY, authToken);
  }

  constructor(private http: HttpClient) { }

  login(loginModel : LoginModel){
    return this.http.post(
      AppSettings.LOGIN_ENDPOINT,
      JSON.stringify(loginModel),
      { headers: new HttpHeaders(
        {"Content-Type" : "application/json"})
      });
  }

  isAuthenticated() : boolean 
  {
    return localStorage.getItem(AppSettings.AUTH_KEY) === this.authToken;
  }

  logOut(){
    localStorage.clear();
    this.authToken = "";
  }
}
