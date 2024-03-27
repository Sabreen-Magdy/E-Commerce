import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/auth.service';
import { IorderAdd, IproductforOrderadd } from 'src/app/models/order';
import { addorderService } from 'src/app/services/AddOrder.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent {
  showerror : boolean = false;
  checkoutForm : FormGroup;
  productVarientperOrder : IproductforOrderadd[] = [];
  constructor( private auth: AuthService, private orderSer:addorderService ){
    this.checkoutForm = new FormGroup({
      // firstname: new FormControl(
      //   "",
      //   [
      //     Validators.required,
      //     Validators.minLength(3),
      //     Validators.pattern('[\u0600-\u06FF]+')
      //   ]
      // ),
      // lastname: new FormControl(
      //   "",
      //   [
      //     Validators.required,
      //     Validators.minLength(3),
      //     Validators.pattern('[\u0600-\u06FF ,]+')
      //   ]
      // ),
      // email: new FormControl(
      //   "",
      //   [
      //     Validators.pattern(/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/)
      //   ]
      // ),
      // phone : new FormControl(
      //   "",
      //   [
      //     Validators.required,
      //     Validators.pattern(/^(010|012|015)[0-9]{8}$/)
      //   ]
      // ),
      mainaddress : new FormControl (
        "",
        [
          Validators.required,
          Validators.minLength(10),
          Validators.pattern('[\u0600-\u06FF ,]+')
        ]
      ),
      // address2 : new FormControl (
      //   "",
      //   [
      //     Validators.minLength(10),
      //     Validators.pattern('[\u0600-\u06FF ,]+')


      //   ]
      // ),
    }
    );
  }
 
  

  // get firstnamecontrol(){
  //   return this.checkoutForm.get('firstname')
  // }
  // get lastnamecontrol(){
  //   return this.checkoutForm.get('lastname')
  // }
  // get emailcontrol(){
  //   return this.checkoutForm.get('email')
  // }
  // get phonecontrol(){
  //   return this.checkoutForm.get('phone')
  // }
  
  // get address2control(){
  //   return this.checkoutForm.get('address2')
  // }

  get mainaddresscontrol(){
    return this.checkoutForm.get('mainaddress')
  }

  enter(e:Event){
    console.log(this.checkoutForm.valid);
   }

   SendOrder(e:Event){
    console.log(new Date().toISOString());
      if (this.checkoutForm.valid){
        
        const order : IorderAdd = {
          customerId: this.auth.id,
          orderDate: new Date().toISOString(),
          customerAddress: this.checkoutForm.get('mainaddress')?.value,
          productsperOrder: [{
            productVarientId: 20,
            quantity: 1,
            totalCost: 1680
          }]
        }
        console.log(order);
        this.orderSer.addorder(order).subscribe({
          next: (data) => {
            console.log("done"+data);
          },
          error : (e) => {
            console.log(e);
          }
        })
      }else{
        this.showerror=true;
      }
      
   }

}
