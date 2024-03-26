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
  showerror : boolean = false;

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
          Validators.pattern(/^(010|012|015)[0-9]{8}$/)
        ]
      ),
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
    return this.signupform.get('name')
  }
  get phonecontrol(){
    return this.signupform.get('phone')
  }
  get emailcontrol(){
    return this.signupform.get('email')
  }
  get passwordcontrol(){
    return this.signupform.get('password')
  }
  get confirmpasswordcontrol(){
    return this.signupform.get('confirmpassword')
  }
  errorMessage:string="";
  submitRegisterForm(e : Event){
    e.preventDefault();
    if (this.signupform.valid){
      console.log(this.signupform.value);
      this._AuthService.signUp(this.signupform.value).subscribe({
      next:(response)=>{
        console.log("ffff",response)
        this._Router.navigate(['/main/signin']);
       
      },
      error : (e) => {
        console.log(e);
      }
    })
    }
    else{
      this.showerror = true
    }
    

  }
}

