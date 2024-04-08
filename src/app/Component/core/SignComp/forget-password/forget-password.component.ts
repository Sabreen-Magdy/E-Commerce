import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.css']
})
export class ForgetPasswordComponent {

  showerror : boolean = false;
  waitsend : boolean = false;
  btnText : string = "إعادة التعيين";
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

  get emailcontrol() {
    return this.forgtForm.get('email');
  }
  ForgetSub(e:Event){
    if (this.forgtForm.valid){
      this.waitsend = true;
      this.btnText = "";
      let email = this.forgtForm.get('email')?.value;
      this.authServ.forgetPassWord(email).subscribe({
        next: (data) => {
          console.log(data);
          this.authServ.otp = data.otp;
          this.authServ.tokenForget = data.token;
          this.authServ.email=email;
          Swal.fire({
            icon : 'success',
            text : "تم ارسال الكود عبر بريدك الالكتروني",
            confirmButtonColor : '#198754'
          }).then(
            (r)=>{
              if (r.isConfirmed){
                this.rout.navigate(['/OTP']);
              }
            }
          )
          
        },
        error : (e) => {
          console.log(e);
          Swal.fire({
            icon:'error',
            text : 'هذا البريد غير مسجل'
          })
        }
      })
    }else{
      this.showerror = true;
    }
  }

}
