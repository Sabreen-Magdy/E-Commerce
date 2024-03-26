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
  showerror : boolean =false;
  unauthorized : boolean = false;

  constructor(private _AuthService:AuthService , private _Router:Router){
    this.signinform = new FormGroup({
      email: new FormControl(
        "",
        [
          Validators.required,
          Validators.pattern(/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.com$/)
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
    return this.signinform.get('email')
  }
  get passwordcontrol(){
    return this.signinform.get('password')
  }

  errorMessage:string="";
  // submitLoginForm(signinform:FormGroup){
  //   // console.log(signinform.value);
  //   this._AuthService.signIn(signinform.value.email,signinform.value.password);
  //   this._Router.navigate(['/home']);
    // console.log(this._AuthService.getUserId())
  submitLoginForm(e:Event){
      if (this.signinform.valid){
        // console.log(this.signinform.value);
        // console.log(this.signinform.value.email);
        this._AuthService.signIn(this.signinform.value.email,this.signinform.value.password).subscribe({
          next : (g) => {
            console.log(g,"goooood");
            this._Router.navigate(['/home']);
          },
          error : (e) => {
            console.log(e);
            this.unauthorized= true
          }
        })

      }else {
        this.showerror = true;
      }
  }
}
