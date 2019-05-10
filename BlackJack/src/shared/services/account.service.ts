import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RequestSignUpAccountView } from '../models/Account/requestSignUpAccountView';
import { ResponseSignUpAccountView } from '../models/Account/responseSignUpAccountView';
import { ResponseGetUsersAccountView } from '../models/Account/responseGetUsersAccountView';
import { environment } from '../../environments/environment';
import * as jwt_decode from "jwt-decode";
import { ResponseTokenAccountView } from '../models/Account/responseTokenAccountView';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class AccountService {
  readonly rootUrl = environment.apiUrl;
  
  invalidLogin: boolean;

  constructor(private http:HttpClient, private router: Router,) { }

  public login(user : RequestSignUpAccountView){
    var token = this.http.post<ResponseTokenAccountView>(this.rootUrl + 'Account/Login', user);
    token.subscribe(
      (response)=>{
        localStorage.setItem('token', response.token);
        this.router.navigateByUrl('choose');
      }
    );
  }

  public get(userId : string){
    return this.http.get<ResponseSignUpAccountView>(this.rootUrl + 'Account/Get/?id=' + userId);
  }

  public getNames(){
    return this.http.get<ResponseGetUsersAccountView>(this.rootUrl + 'Account/GetUsers/');
  }
  
  public getUserId() {
    var token = localStorage.getItem('token');
    var tokenClaims = jwt_decode(token, "");
    return tokenClaims.UserId;
  }

  public logout() {
    localStorage.removeItem('token');
  }
}
