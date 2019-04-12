import { Component, OnInit, Input, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AccountService } from '../../../shared/services/account.service';
import { Router } from '@angular/router';
import { RequestSignUpAccountView } from '../../../shared/models/Account/RequestSignUpAccountView';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  signUpControl: FormGroup;

  signUpmodel : RequestSignUpAccountView = new RequestSignUpAccountView;

  constructor(private service: AccountService, private router: Router) { }

  ngOnInit() {
    if (localStorage.getItem('token')!= null) {
      //this.router.navigateByUrl('game')
    }
    this.signUpControl = new FormGroup({
      UserName: new FormControl()
    })
  }

  onLogin(){
    this.service.login(this.signUpmodel).subscribe(
      (res:any)=>{
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('game');
      }
    );
  }

  onSignUp(){
    this.service.signUp(this.signUpmodel).subscribe()
    this.router.navigateByUrl('game');
  }

}


