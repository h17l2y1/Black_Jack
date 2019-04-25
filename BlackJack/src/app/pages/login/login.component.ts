import { Component, OnInit, Input, Output } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators  } from '@angular/forms';
import { AccountService } from '../../../shared/services/account.service';
import { Router } from '@angular/router';
import { RequestSignUpAccountView } from '../../../shared/models/Account/RequestSignUpAccountView';
import { ResponseGetUsersAccountView } from '../../../shared/models/Account/ResponseGetUsersAccountView';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: []
})
export class LoginComponent implements OnInit {

  signUpmodel = new RequestSignUpAccountView;
  namesModel = new ResponseGetUsersAccountView;
  loginForm: FormGroup;
  temp: string = null;
  isLoginNull = false;

  constructor(private service: AccountService, private router: Router, private fb: FormBuilder) { }

  ngOnInit() {
    if (localStorage.getItem('token')!= null) {
      this.router.navigateByUrl('choose')
    }
    this.initForm();
    this.getNames();
  }

  onTempName(temp:string){
    this.temp = temp;
    this.initForm();
  }

  getNames(){
    this.service.getNames()
    .subscribe((response) => {
      this.namesModel = response
    });
  }

  initForm(){
    this.loginForm = this.fb.group({
     Name: [this.temp]
    });
  }

  onLogin(){
    if (this.loginForm.value.Name == null) {
      this.isLoginNull = true;
    }
    if (this.loginForm.value.Name != null) {
      this.isLoginNull = false;
      this.logining();
    }
  }

  logining(){
    this.signUpmodel.userName = this.loginForm.value.Name;
    this.service.login(this.signUpmodel).subscribe(
      (res:any)=>{
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('choose');
      }
    );
  }
}


