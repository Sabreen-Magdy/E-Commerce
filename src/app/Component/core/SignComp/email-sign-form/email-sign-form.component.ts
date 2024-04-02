import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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

  ConfirmEmail(e:Event){
    if (this.signupform.valid){

    }else{
      this.showerror=true;
    }

  }
}
