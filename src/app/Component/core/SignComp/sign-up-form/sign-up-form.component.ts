import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrls: ['./sign-up-form.component.css']
})
export class SignUpFormComponent {
  signupform : FormGroup;

  constructor(private _AuthService:AuthService , private _Router:Router){
    this.signupform = new FormGroup({
      name: new FormControl(
        "",
        [
          Validators.required,
          Validators.minLength(3),
          Validators.pattern('[\u0600-\u06FF ,]+')
        ]
      ),
      phone: new FormControl(
        "",
        [
          Validators.required,
          Validators.minLength(11),
          Validators.maxLength(11)
          // Validators.pattern('[\u0600-\u06FF]+')
        ]
      ),
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
  // Custom validator function to compare password and confirm password
  passwordMatchValidator(control: AbstractControl) {
    return control.get('password')?.value ===
    control.get('confirmpassword')?.value
    ? null
    : { mismatch : true };
   }

   enter(e:Event){
    console.log(this.signupform.valid);
    console.log(this.signupform.hasError('mismatch'));
    console.log(this.confirmpasswordcontrol?.valid);
   }

  get firstnamecontrol(){
    return this.signupform.get('Name')
  }
  get phonecontrol(){
    return this.signupform.get('Phono')
  }
  get emailcontrol(){
    return this.signupform.get('Email')
  }
  get passwordcontrol(){
    return this.signupform.get('Password')
  }
  get confirmpasswordcontrol(){
    return this.signupform.get('confirmpassword')
  }
  errorMessage:string="";
  submitRegisterForm(signupform:FormGroup){
    console.log(signupform.value);
    this._AuthService.signUp(signupform.value).subscribe({
      next:(response)=>{
        console.log("ffff",response)
        this._Router.navigate(['/main/signin']);
        // if(response.message==='Success'){
        //   //navigate home page
        //   console.log("S");
        // }else{
        //   console.log("F");
        //   this.errorMessage=response.message;

        // }
      }
    })

  }
}

