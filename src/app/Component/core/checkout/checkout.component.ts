import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth.service';
import { CartDto } from 'src/app/models/icart';
import { IorderAdd, IproductforOrderadd } from 'src/app/models/order';
import { addorderService } from 'src/app/services/AddOrder.service';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent {
  buttonText:string="الاستمرار في تأكيد الطلب"
  showerror : boolean = false;
  checkoutForm : FormGroup;
  numOfItemInCart:number=0;
  customerID : number = 0;
  cart : CartDto = {
    totalPrice: 0,
    totalQuantity: 0,
    items: []
  };
  cartByIDsub : Subscription | undefined;
  productVarientperOrder : IproductforOrderadd[] = [];
  constructor( private auth: AuthService, private orderSer:addorderService ,private cartService:CartService){
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
ngOnInit(){
  this.customerID = this.auth.id;
  this.getcartbyId()
  this.cartService.numberOfitemInCart.subscribe({
    next:()=>{
       this.numOfItemInCart=this.cartService.numberOfitemInCart.getValue();
    }
  });
}
  get mainaddresscontrol(){
    return this.checkoutForm.get('mainaddress')
  }
  getcartbyId(){
    console.log(this.customerID);
    this.cartByIDsub = this.cartService.getCartBycstId(this.customerID).subscribe({
      next : (data) =>{
        let filterdata = data.items.filter((item)=>item.state==0);
        let totalPriceS : number = 0;
        // this.cart.items = this.cart.items.filter((item)=>item.state==0)
        for (var item of filterdata){
          totalPriceS += item.unitPrice * item.quantity
        }
        this.cart = data;
        this.cart.items = this.cart.items.filter((item)=>item.state==0);
        this.cart.totalPrice = totalPriceS;
        console.log("cart" ,this.cart);
      },
      error : (e) =>{
        console.log("ERROR when fetch Data of CartItem" + e);
      }
    })
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
        this.buttonText = 'تم ارسال طلبك...';
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
