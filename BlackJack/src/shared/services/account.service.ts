import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient, HttpHeaders } from '@angular/common/http';
import { RequestSignUpAccountView } from '../models/Account/RequestSignUpAccountView';
import { ResponseSignUpAccountView } from '../models/Account/ResponseSignUpAccountView';

@Injectable({
  providedIn: 'root'
})

export class AccountService {
  readonly rootUrl = "http://localhost:52077/";
  
  invalidLogin: boolean;
  router: any;

  constructor(private http:HttpClient) { }

  public signUp(user : RequestSignUpAccountView){
    return this.http.post(this.rootUrl + 'api/Account/SignUp', user);
  }

  public login(user : RequestSignUpAccountView){
    return this.http.post(this.rootUrl + 'api/Account/Login', user);
  }

  public get(userId : string){
    return this.http.get<ResponseSignUpAccountView>(this.rootUrl + 'api/Account/GetById/' + userId);
  }
  
}
