import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.css']
})
export class ForgetPasswordComponent {

  constructor( private authServ : AuthService , private rout :Router){}
  forgtForm : FormGroup = new FormGroup({
    email: new FormControl(
      "",
      [
        Validators.required,
        Validators.pattern(/^[a-zA-Z0-9_-]+@[a-zA-Z0-9-]+\.com$/)
      ]
    ),

  })

  ForgetSub(e:Event){
    if (this.forgtForm.valid){
      let email = this.forgtForm.get('email')?.value;
      this.authServ.forgetPassWord(email).subscribe({
        next: (data) => {
          console.log(data);
          this.authServ.otp = data.otp;
          this.authServ.tokenForget = data.token;
          this.authServ.email=email
          this.rout.navigate(['/OTP']);
        },
        error : (e) => {
          console.log(e);
        }
      })
    }
  }

}
