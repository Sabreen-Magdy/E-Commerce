import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-rest-password',
  templateUrl: './rest-password.component.html',
  styleUrls: ['./rest-password.component.css']
})
export class RestPasswordComponent {

  signupform : FormGroup;
  showerror : boolean = false;


  constructor(private _AuthService:AuthService , private _Router:Router , ){
    this.signupform = new FormGroup({
      password : new FormControl (
        "",
        [
          Validators.required,
          Validators.pattern(/^(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).+$/),
          Validators.minLength(6),
        ]
      ),
      confirmpassword : new FormControl (
        "",
        [
          Validators.required,
          Validators.minLength(6),
        ]
      ),
    },
    {
      validators : this.passwordMatchValidator
    }
    );
  }
  token:string="";
  otp:string="";
  email:string="";
  newPassword:string="";
  ngOnInit(): void {
    console.log("hiiiiiiiiiiiiiiiiii");
  this.otp=this._AuthService.otp;
  this.token=this._AuthService.tokenForget;
  this.email=this._AuthService.email;
  console.log("OTP",this.otp);
  console.log("token",this.token);
  console.log("email",this.email);
  }


  passwordMatchValidator(control: AbstractControl) {
    return control.get('password')?.value ===
    control.get('confirmpassword')?.value
    ? null
    : { mismatch : true };
   }

  get passwordcontrol(){
    return this.signupform.get('password')
  }
  get confirmpasswordcontrol(){
    return this.signupform.get('confirmpassword')
  }
  submitRegisterForm(e : Event){
    e.preventDefault();
    if (this.signupform.valid){
      let dataUser={
        token:this.token,
        otp:this.otp,
        email:this.email,
        newPassword:this.signupform.get('password')?.value
      }
      this._AuthService.resetPassWord(dataUser).subscribe({
        next: (data) => {
          this._Router.navigate(['/signin']);
        },
        error: (e)=>{
          console.log("ERROR");
          console.log(e);
        }
      })
    }
    else{
      this.showerror = true
    }
  }
}
