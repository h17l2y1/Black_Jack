import { Component, OnInit } from '@angular/core';
import * as jwt_decode from "jwt-decode";
import { TransferService } from '../../../shared/services/transfer.service';
import { AccountService } from '../../../shared/services/account.service';
import { ResponseSignUpAccountView } from '../../../shared/models/Account/responseSignUpAccountView';


@Component({
  selector: 'app-choose',
  templateUrl: './choose.component.html',
  styleUrls: []
})
export class ChooseComponent implements OnInit {

  userModel = new ResponseSignUpAccountView;

  constructor(private accountService: AccountService, private transferService: TransferService) { }

  ngOnInit() {
    this.getUserData();
  }

  onGame(){
    this.transferService.setModel(this.userModel);
  }

  getUserData() {
    var token = localStorage.getItem('token');
    var tokenClaims = jwt_decode(token, "");

    this.userModel.userId = tokenClaims.UserId;
    this.userModel.userName = tokenClaims.UserName;
    this.userModel.role = tokenClaims.Role;
    this.userModel.points = "100";
  }

  onLogout() {
    this.accountService.logout();
  }
}
