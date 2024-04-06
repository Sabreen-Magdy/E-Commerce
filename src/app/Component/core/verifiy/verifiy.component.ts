import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgOtpInputConfig } from 'ng-otp-input';

@Component({
  selector: 'app-verifiy',
  templateUrl: './verifiy.component.html',
  styleUrls: ['./verifiy.component.css']
})
export class VerifiyComponent {

  otpConfig: NgOtpInputConfig = {
    allowNumbersOnly: true,
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

  constructor() {
    this.otpForm = new FormGroup({
      otpCode: new FormControl('', [Validators.required])
    });
  }
  otpCode2 : FormControl = new FormControl('',[Validators.required])

  submit() {
    console.log("hiiiiiiii");
    if (this.otpCode2.valid){
      console.log("Vals");
      console.log(this.otpCode2.value);
    }
    if (this.otpForm.valid) {
      console.log("bto");
      const otpCode = this.otpForm.get('otpCode')?.value;
      console.log("OTP Code:", otpCode);
      // You can perform further actions with the OTP code here
    }
  }
}
