import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../../../shared/services/account.service';
import { ResponseSignUpAccountView } from '../../../shared/models/Account/responseSignUpAccountView';
import * as jwt_decode from "jwt-decode";


@Component({
  selector: 'app-choose',
  templateUrl: './choose.component.html',
  styleUrls: []
})
export class ChooseComponent implements OnInit {

  userModel = new ResponseSignUpAccountView;

  constructor(private router: Router, private accountService: AccountService) { }

  ngOnInit() {
    this.getUserData();
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
