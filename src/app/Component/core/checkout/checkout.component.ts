import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

// import {
//   AbstractControl,
//   FormControl,
//   FormGroup,
//   Validators,
// } from '@angular/forms';
// import { Subscription } from 'rxjs';
// import { AuthService } from 'src/app/auth.service';
// import { CartItemDto, Uppdatecart } from 'src/app/models/icart';
// import { IorderAdd, IproductforOrderadd } from 'src/app/models/order';
// import { addorderService } from 'src/app/services/AddOrder.service';
// import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
})
export class CheckoutComponent implements OnInit {
  //Form Validables
registerForm:any= FormGroup;
submitted = false;
constructor( private formBuilder: FormBuilder){}
  // showerror: boolean = false;
  // customerID: number = 0;
  // noitem: boolean = false;
  // wiating: boolean = false;
  // doneOrder: boolean = false;
  // errorOrder: boolean = false;
  // deleteOrder: boolean = false;
  // waitingDelete: boolean = false;
  // checkoutForm: FormGroup;
  // btnText: string = 'الاستمرار في تأكيد الطلب';
  // delText: string = 'الغاء الطلب';
  // productVarientperOrder: IproductforOrderadd[] = [];
  // nameProductVarient: string[] = [];
  // cartitemfordelete: CartItemDto[] = [];
  // totalPrice: number = 0;
  // constructor(
  //   private auth: AuthService,
  //   private orderSer: addorderService,
  //   private CartService: CartService
  // ) {
  //   this.checkoutForm = new FormGroup({
  //     mainaddress: new FormControl('', [
  //       Validators.required,
  //       Validators.minLength(10),
  //       Validators.pattern('[\u0600-\u06FF ,]+'),
  //     ]),
  //   });
  // }
  // ngOnInit(): void {
  //   this.customerID = this.auth.id;
  //   this.getcartbyId();
  // }

  // cartByIDsub: Subscription | undefined;
  // deletecartAfCheckSub: Subscription | undefined;

  // get mainaddresscontrol() {
  //   return this.checkoutForm.get('mainaddress');
  // }

  // deleteafterCheckout2() {
  //   for (let item of this.cartitemfordelete) {
  //     this.deletecartAfCheckSub = this.CartService.deleteCartitem(
  //       item.id
  //     ).subscribe({
  //       next: () => {
  //         console.log('Delete success ');
  //       },
  //       error: (e) => {
  //         console.log('ERROR when delete', e);
  //       },
  //     });
  //   }
  // }
  // getcartbyId() {
  //   console.log('dkdkd');
  //   console.log(this.customerID);
  //   this.cartByIDsub = this.CartService.getCartBycstId(
  //     this.customerID
  //   ).subscribe({
  //     next: (data) => {
  //       let filterdata = data.items.filter((item) => item.state == 1);
  //       let totalPriceS: number = 0;
  //       for (var item of filterdata) {
  //         totalPriceS += item.unitPrice * item.quantity;
  //         let PVI: IproductforOrderadd = {
  //           productVarientId: item.productVarientId,
  //           quantity: item.quantity,
  //           totalCost: item.unitPrice * item.quantity,
  //         };
  //         this.productVarientperOrder.push(PVI);
  //         this.nameProductVarient.push(item.name);
  //       }
  //       this.totalPrice = totalPriceS;
  //       this.cartitemfordelete = filterdata;
  //       if (this.productVarientperOrder.length == 0) {
  //         this.noitem = true;
  //       }
  //     },
  //     error: (e) => {
  //       this.noitem = true;
  //       console.log('ERROR when fetch Data of CartItem' + e);
  //     },
  //   });
  // }

  // SendOrder(e: Event) {
  //   console.log(new Date().toISOString());
  //   if (this.checkoutForm.valid) {
  //     this.wiating = true;
  //     this.btnText = '';
  //     const order: IorderAdd = {
  //       customerId: this.customerID,
  //       orderDate: new Date().toISOString(),
  //       customerAddress: this.checkoutForm.get('mainaddress')?.value,
  //       productsperOrder: this.productVarientperOrder,
  //     };
  //     console.log(order);
  //     this.orderSer.addorder(order).subscribe({
  //       next: (data) => {
  //         console.log('done' + data);
  //         this.doneOrder = true;
  //         this.deleteafterCheckout2();
  //       },
  //       error: (e) => {
  //         console.log('error when send order', e);
  //         this.errorOrder = true;
  //         this.deleteafterCheckout2();
  //       },
  //     });
  //   } else {
  //     this.showerror = true;
  //   }
  // }

  // cancelOrder() {
  //   this.waitingDelete = true;
  //   this.delText = '';
  //   let len: number = this.cartitemfordelete.length;
  //   if (len > 0) {
  //     let i = 0;

  //     for (let item of this.cartitemfordelete) {
  //       this.deletecartAfCheckSub = this.CartService.deleteCartitem(
  //         item.id
  //       ).subscribe({
  //         next: () => {
  //           console.log('Delete success ');
  //           if (i == len -1){
  //             this.deleteOrder = true;
  //             this.waitingDelete =false;
  //           }else{
  //             i++
  //           }
  //         },
  //         error: (e) => {
  //           console.log('ERROR when delete', e);
  //           if (i == length - 1){
  //             this.waitingDelete = false;
  //             this.getcartbyId();
  //           }
  //         },
  //       });
  //     }
  //   }
  // }

//Add user form actions
get f() { return this.registerForm.controls; }
onSubmit() {

  this.submitted = true;
  // stop here if form is invalid
  if (this.registerForm.invalid) {
      return;
  }
  //True if all the fields are filled
  if(this.submitted)
  {
    alert("Great!!");
  }

}
ngOnInit() {
  //Add User form validations
  this.registerForm =new FormGroup({
    Governorate: new FormControl("", [Validators.required,Validators.pattern('[\u0600-\u06FF ,]+')]),
    place: new FormControl("", [Validators.required,Validators.pattern('[\u0600-\u06FF ,]+')]),
    residential_area: new FormControl( "", [Validators.required,Validators.pattern('[\u0600-\u06FF ,]+')]),
    phone: new FormControl(
      "",
      [
        Validators.required,
        Validators.pattern(/^(010|012|015|011)[0-9]{8}$/)
      ]
    ),
  });
}




}
