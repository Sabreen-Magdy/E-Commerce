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
  otp:string="";
  token:any;
  id:number=0;
  ngOnInit(): void {
    console.log("hiiiiiiiiiiiiiiiiii");
  this.otp=this._AuthService.otp;
  this.token=this._AuthService.tokenForget;
  console.log("OTP" , this.otp);
  console.log("Token", this.token);
  let decodeTok:any=jwtDecode(this.token);
  console.log("deeeeeeeeeeee",decodeTok)
  // this.id=decodeTok.id;
  // console.log("OTP",this.token);
  
  // console.log("idddddddddd",this.id)

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



    }
    else{
      this.showerror = true
    }


  }
}
