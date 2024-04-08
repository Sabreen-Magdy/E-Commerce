import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgOtpInputConfig } from 'ng-otp-input';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-verifiy',
  templateUrl: './verifiy.component.html',
  styleUrls: ['./verifiy.component.css']
})
export class VerifiyComponent implements OnInit {
  
  showerroOtp : boolean = false;
  otp : string = "";
  waitSend : boolean = false;
  btntext : string = "تأكيد الكود";
  
  otpConfig: NgOtpInputConfig = {
    allowNumbersOnly: false,
    length: 6,
    isPasswordInput: false,
    disableAutoFocus: false,
    placeholder: '',
    inputStyles: {
      'display': 'flex'
    },
    containerStyles: {
      'display': 'flex'
    },
    inputClass: 'each_input',
    containerClass: 'all_inputs'
  };

  otpForm: FormGroup;

  constructor( private authServ : AuthService , private _Router :Router ) {
    this.otpForm = new FormGroup({
      otpCode: new FormControl('', [Validators.required])
    });
  }
  ngOnInit(): void {
    this.otp = this.authServ.otp;
  }
  otpCode2 : FormControl = new FormControl('',[Validators.required])

  submit(e:Event) {
    e.preventDefault();
    if (this.otpCode2.valid){
      this.btntext ="";
      this.waitSend = true;
      const otpCode = this.otpCode2.value;
     
      if (otpCode == this.otp){
        
        this._Router.navigate(['/resetpassword']);
      }else {
        this.showerroOtp = true; 
        this.waitSend = false;
        this.btntext = "تأكيد الكود";
      }
      // You can perform further actions with the OTP code here
    }
  }
}
