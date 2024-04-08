import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-email-sign-form',
  templateUrl: './email-sign-form.component.html',
  styleUrls: ['./email-sign-form.component.css']
})
export class EmailSignFORMComponent {

  signupform : FormGroup;
  showerror : boolean = false;
  waitresponse : boolean = false;
  btnText : string = "انشاء الحساب";
  constructor(private _AuthService:AuthService , private _Router:Router)
  {
    this.signupform = new FormGroup({

      email: new FormControl(
        "",
        [
          Validators.required,
          Validators.pattern(/^[a-zA-Z0-9_-]+@[a-zA-Z0-9-]+\.com$/)
        ]
      ),

    },

    );
  }

  get emailcontrol(){
    return this.signupform.get('email')
  }

  confirmSub : Subscription | undefined;

  ConfirmEmail(e:Event){
    
    if (this.signupform.valid){
      this.waitresponse = true;
      this.btnText ="";
      let email :string = this.signupform.get('email')?.value;
      // console.log(email);
      this.confirmSub = this._AuthService.confirmEmail(email).subscribe({
        next: (e) => {
          this.waitresponse = false;
          this.btnText ="اذهب للبريد الان"
          Swal.fire({
     
      
            title: 'تأكيد البريد الالكتروني',
            text : 'لقد قمنا بإرسال رسالة إلكترونية إلى عنوان البريد الإلكتروني الخاص بكم.',
            imageUrl : 'https://cdn.icon-icons.com/icons2/1229/PNG/512/1492692368-7email_83536.png',
            imageHeight : 100,
            imageWidth : 100,
            confirmButtonColor: '#198754', // Change this to the color you prefer
            
       });
          console.log("Doneeeeeeeeeeeeeee");
          console.log(e);
        },

        error : (e) => {
          this.waitresponse = false;
          this.btnText ="انشاء الحساب "
          Swal.fire({
     
      
            title: 'البريد الإلكتروني مستخدم بالفعل',
            text : 'تنبيه: البريد الإلكتروني الذي أدخلته مسجل مسبقاً. الرجاء استخدام الخيار \'نسيت كلمة المرور؟\' إذا كنت تحتاج إلى إعادة تعيين كلمة المرور الخاصة بك.',
            icon : 'error',
            confirmButtonColor: '#198754', // Change this to the color you prefer
            
       });
          console.log("ERROR" , e);
        }
      })

    }else{
      this.showerror=true;
    }

  }
}
