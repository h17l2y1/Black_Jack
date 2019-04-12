import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AccountService } from '../../../shared/services/account.service';
import { RequestSignUpAccountView } from '../../../shared/models/Account/RequestSignUpAccountView';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  signUpmodel : RequestSignUpAccountView = new RequestSignUpAccountView;

  constructor(private service: AccountService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form? : NgForm){
    if(form != null)
    form.reset();
    // this.signUpmodel = {
    //   userName: ''
    // }
  }

  onSubmit(form : NgForm){
    this.service.signUp(form.value)
    .subscribe((data: any) => {
      this.resetForm();
    })

  }

}
