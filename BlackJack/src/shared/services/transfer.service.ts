import { Injectable, EventEmitter } from '@angular/core';
import { ResponseSignUpAccountView } from '../models/Account/responseSignUpAccountView';

@Injectable({
  providedIn: 'root'
})
export class TransferService {

  userModel = new ResponseSignUpAccountView;
  public modelAdded$: EventEmitter<ResponseSignUpAccountView>;

  constructor() { 
    this.modelAdded$ = new EventEmitter(); 
  }

  public getModel(): ResponseSignUpAccountView {
    return this.userModel;
  }

  public setModel(model: ResponseSignUpAccountView): void {
    this.userModel = model;
    this.modelAdded$.emit(model);
  }


}
