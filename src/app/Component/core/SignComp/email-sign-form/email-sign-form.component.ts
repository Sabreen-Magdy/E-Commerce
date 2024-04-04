import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-email-sign-form',
  templateUrl: './email-sign-form.component.html',
  styleUrls: ['./email-sign-form.component.css']
})
export class EmailSignFORMComponent {

  signupform : FormGroup;
  showerror : boolean = false;
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
      let email :string = this.signupform.get('email')?.value;
      // console.log(email);
      this.confirmSub = this._AuthService.confirmEmail(email).subscribe({
        next: (e) => {
          console.log("Doneeeeeeeeeeeeeee");
          console.log(e);
        },

        error : (e) => {
          console.log("ERROR" , e);
        }
      })
      
    }else{
      this.showerror=true;
    }

  }
}
