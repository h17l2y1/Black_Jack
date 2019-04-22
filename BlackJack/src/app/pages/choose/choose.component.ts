import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as jwt_decode from "jwt-decode";
import { AccountService } from '../../../shared/services/account.service';
import { ResponseSignUpAccountView } from '../../../shared/models/Account/ResponseSignUpAccountView';


@Component({
  selector: 'app-choose',
  templateUrl: './choose.component.html',
  // styleUrls: ['./choose.component.css']
  styleUrls: []
})
export class ChooseComponent implements OnInit {

  userModel = new ResponseSignUpAccountView;

  constructor(private router: Router, private accountService: AccountService) { }

  ngOnInit() {
    this.getUserData();
  }

  getUserData() {
    var userId = this.getUserId()
    this.accountService.get(userId)
      .subscribe((response) => {
        this.userModel = response;
      });
  }

  getUserId() {
    var token = localStorage.getItem('token');
    var tokenClaims = jwt_decode(token, "");
    return tokenClaims.UserId;
  }

  onLogout() {
    localStorage.removeItem('token');
    // this.router.navigate(['login']);
  }
}
