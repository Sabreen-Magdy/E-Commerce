import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { IRegisteration } from 'src/app/models/auth';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrls: ['./sign-up-form.component.css']
})
export class SignUpFormComponent implements OnInit {
  signupform : FormGroup;
  showerror : boolean = false;
  emailUser : string = "";
  
  constructor(private _AuthService:AuthService , private _Router:Router , private actRoute : ActivatedRoute){
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
          Validators.pattern(/^(010|012|015|011)[0-9]{8}$/)
        ]
      ),
      email: new FormControl(
        "",
        [
          Validators.required,
          Validators.pattern(/^[a-zA-Z0-9_-]+@[a-zA-Z0-9-]+\.com$/)
        ]
      ),
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
  ngOnInit(): void {
    this.emailUser = this.actRoute.snapshot.queryParams['email'];
    this.signupform.get('email')?.setValue(this.emailUser);
  }

  
  passwordMatchValidator(control: AbstractControl) {
    return control.get('password')?.value ===
    control.get('confirmpassword')?.value
    ? null
    : { mismatch : true };
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
  submitRegisterForm(e : Event){
    e.preventDefault();
    if (this.signupform.valid){
      let dataUser : IRegisteration = {
        name: this.signupform.get('name')?.value,
        image: 'image.png',
        email: this.emailUser,
        password: this.signupform.get('password')?.value,
        phone: this.signupform.get('phone')?.value,
        address: ''
      }

      console.log(dataUser);
      this._AuthService.Registeration(dataUser).subscribe({
        next: (data) => {
          console.log("Welcome");
          console.log(data);
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

