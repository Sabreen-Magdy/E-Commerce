import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
@Component({
  selector: 'app-signin-form',
  templateUrl: './signin-form.component.html',
  styleUrls: ['./signin-form.component.css']
})
export class SigninFormComponent {
  signinform : FormGroup;

  constructor(private _AuthService:AuthService , private _Router:Router){
    this.signinform = new FormGroup({
      email: new FormControl(
        "",
        [
          Validators.required,
          Validators.pattern(/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/)
        ]
      ),
      password : new FormControl (
        "",
        [
          Validators.required,
          Validators.minLength(6),
        ]
      ),
    }
    );
  }

  //  enter(e:Event){
  //   console.log(this.signupform.valid);
  //   console.log(this.signupform.hasError('mismatch'));
  //   console.log(this.confirmpasswordcontrol?.valid);
  //  }


  get emailcontrol(){
    return this.signinform.get('Email')
  }
  get passwordcontrol(){
    return this.signinform.get('Password')
  }

  errorMessage:string="";
  submitLoginForm(signinform:FormGroup){
    console.log(signinform.value);
    this._AuthService.signIn(signinform.value.email,signinform.value.password);
    this._Router.navigate(['/home']);
    // console.log(this._AuthService.getUserId())
  }
}
