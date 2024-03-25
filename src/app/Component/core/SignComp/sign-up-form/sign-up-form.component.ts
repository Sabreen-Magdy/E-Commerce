import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrls: ['./sign-up-form.component.css']
})
export class SignUpFormComponent {
  signupform : FormGroup;

  constructor(){
    this.signupform = new FormGroup({
      firstname: new FormControl(
        "",
        [
          Validators.required,
          Validators.minLength(3),
          Validators.pattern('[\u0600-\u06FF]+')
        ]
      ),
      lastname: new FormControl(
        "",
        [
          Validators.required,
          Validators.minLength(3),
          Validators.pattern('[\u0600-\u06FF]+')
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
    return this.signupform.get('firstname')
  }
  get lastnamecontrol(){
    return this.signupform.get('lastname')
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
  
}
