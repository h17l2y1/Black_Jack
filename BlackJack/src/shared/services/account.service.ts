import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient, HttpHeaders } from '@angular/common/http';
import { RequestSignUpAccountView } from '../models/Account/requestSignUpAccountView';
import { ResponseSignUpAccountView } from '../models/Account/responseSignUpAccountView';
import { ResponseGetUsersAccountView } from '../models/Account/responseGetUsersAccountView';

@Injectable({
  providedIn: 'root'
})

export class AccountService {
  readonly rootUrl = "http://localhost:52077/";
  
  invalidLogin: boolean;
  router: any;

  constructor(private http:HttpClient) { }

  public login(user : RequestSignUpAccountView){
    return this.http.post(this.rootUrl + 'api/Account/Login', user);
  }

  public get(userId : string){
    return this.http.get<ResponseSignUpAccountView>(this.rootUrl + 'api/Account/Get/' + userId);
  }

  public getNames(){
    return this.http.get<ResponseGetUsersAccountView>(this.rootUrl + 'api/Account/GetUsers/');
  }
  
}
