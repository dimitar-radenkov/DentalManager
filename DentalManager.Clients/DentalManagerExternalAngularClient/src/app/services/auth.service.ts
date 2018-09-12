import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { LoginModel } from '../models/LoginModel';

const url = "https://localhost:44391/api/authorization/login";
const auth_key = "auth_token";

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
    localStorage.setItem(auth_key, this.authToken);
  }

  constructor(private http: HttpClient) { }

  login(loginModel : LoginModel){
    return this.http.post(
      url,
      JSON.stringify(loginModel),
      { headers: new HttpHeaders(
        {"Content-Type" : "application/json"})
      });
  }

  isAuthenticated() : boolean 
  {
    return localStorage.getItem(auth_key) === this.authToken;
  }

  logOut(){
    localStorage.clear();
    this.authToken = "";
  }
}
