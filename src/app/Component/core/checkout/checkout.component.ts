import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent {
  checkoutForm : FormGroup;

  constructor(){
    this.checkoutForm = new FormGroup({
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
          Validators.pattern('[\u0600-\u06FF ,]+')
        ]
      ),
      email: new FormControl(
        "",
        [
          Validators.pattern(/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/)
        ]
      ),
      phone : new FormControl(
        "",
        [
          Validators.required,
          Validators.pattern(/^(010|012|015)[0-9]{8}$/)
        ]
      ),
      mainaddress : new FormControl (
        "",
        [
          Validators.required,
          Validators.minLength(10),
          Validators.pattern('[\u0600-\u06FF ,]+')
        ]
      ),
      address2 : new FormControl (
        "",
        [
          Validators.minLength(10),
          Validators.pattern('[\u0600-\u06FF ,]+')


        ]
      ),
    }
    );
  }
 
   enter(e:Event){
    console.log(this.checkoutForm.valid);
   }

  get firstnamecontrol(){
    return this.checkoutForm.get('firstname')
  }
  get lastnamecontrol(){
    return this.checkoutForm.get('lastname')
  }
  get emailcontrol(){
    return this.checkoutForm.get('email')
  }
  get phonecontrol(){
    return this.checkoutForm.get('phone')
  }
  get mainaddresscontrol(){
    return this.checkoutForm.get('mainaddress')
  }
  get address2control(){
    return this.checkoutForm.get('address2')
  }

}
