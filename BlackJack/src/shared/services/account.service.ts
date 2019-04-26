import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RequestSignUpAccountView } from '../models/Account/requestSignUpAccountView';
import { ResponseSignUpAccountView } from '../models/Account/responseSignUpAccountView';
import { ResponseGetUsersAccountView } from '../models/Account/responseGetUsersAccountView';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class AccountService {
  readonly rootUrl = environment.apiUrl;
  
  invalidLogin: boolean;
  router: any;

  constructor(private http:HttpClient) { }

  public login(user : RequestSignUpAccountView){
    return this.http.post(this.rootUrl + 'Account/Login', user);
  }

  public get(userId : string){
    return this.http.get<ResponseSignUpAccountView>(this.rootUrl + 'Account/Get/' + userId);
  }

  public getNames(){
    return this.http.get<ResponseGetUsersAccountView>(this.rootUrl + 'Account/GetUsers/');
  }
  
}
