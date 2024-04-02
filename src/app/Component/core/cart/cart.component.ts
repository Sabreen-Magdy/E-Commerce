import { Router } from '@angular/router';
import { Uppdatecart } from './../../../models/icart';
import { CartService } from './../../../services/cart.service';
import { Component, OnInit } from '@angular/core';
import { filter, Subscribable, Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth.service';
import { CartDto, CartItemDto } from 'src/app/models/icart';
import { ComponentUrl } from 'src/app/models/unit';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { addorderService } from 'src/app/services/AddOrder.service';
import { IorderAdd, IproductforOrderadd } from 'src/app/models/order';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  ComponentUrl = ComponentUrl;
  buttonText: string = 'تأكيد الطلب';
  customerID: number = 0;
  cart: CartDto = {
    totalPrice: 0,
    totalQuantity: 0,
    items: [],
  };

  noitem: boolean = false;
  wiating: boolean = false;
  isMaxThanAvailable: boolean = false;
  waitUpdatNumber: boolean = false;
  isZero: boolean = false;
  lastitemChange: number = 0;



  /**  ====   checkOut       ========= */
  registerForm:FormGroup = new FormGroup({
    Governorate: new FormControl("", [Validators.required,Validators.pattern('[\u0600-\u06FF ,]+')]),
    place: new FormControl("", [Validators.required,Validators.pattern('[\u0600-\u06FF ,]+')]),
    residential_area: new FormControl( "", [Validators.required,Validators.pattern('[\u0600-\u06FF ,]+')]),
  });;

  get GovernorateAddresscontrol() {
    return this.registerForm.get('Governorate');
  }get placeAddresscontrol() {
    return this.registerForm.get('place');
  }
  get residential_areaAddresscontrol() {
    return this.registerForm.get('residential_area');
  }
  submitted = false;
  productVarientperOrder: IproductforOrderadd[] = [];
  nameProductVarient: string[] = [];
  cartitemforelete: CartItemDto[] = [];
  totalPrice: number = 0;
  showerror: boolean = false;
  doneOrder: boolean = false;
  errorOrder: boolean = false;
  deleteOrder: boolean = false;
  waitingSendOrder: boolean = false;
  btnText: string = 'الاستمرار في تأكيد الطلب';
  delText: string = this.doneOrder ? "قفل" : "الغاء الطلب";

  deletecartAfCheckSub: Subscription | undefined;
  constructor(
    private CartService: CartService,
    private authServ: AuthService,
    private orderSer: addorderService,
    private _Router: Router
  ) {}
  ngOnInit(): void {
    this.customerID = this.authServ.id;
    this.getcartbyId();
    this.CartService.getNumberOfitemInCart();
  }

  cartByIDsub: Subscription | undefined;
  delCartItemsub: Subscription | undefined;
  updateCartItemsub: Subscription | undefined;

  getcartbyId() {
    console.log('dkdkd');
    console.log(this.customerID);
    this.cartByIDsub = this.CartService.getCartBycstId(
      this.customerID
    ).subscribe({
      next: (data) => {
        let filterdata = data.items.filter((item) => item.state == 0);
        let totalPriceS: number = 0;
        // this.cart.items = this.cart.items.filter((item)=>item.state==0)
        for (var item of filterdata) {
          item.unitPrice = item.unitPrice - (item.unitPrice*item.discount)
          totalPriceS += item.unitPrice * item.quantity;
        }
        this.cart = data;
        this.cart.items = filterdata;
        this.cart.totalPrice = totalPriceS;
        console.log('cart', this.cart);
        if (filterdata.length == 0) {
          this.noitem = true;
        }
        this.waitUpdatNumber = false;
      },
      error: (e) => {
        this.noitem = true;
        console.log('ERROR when fetch Data of CartItem' + e);
      },
    });
  }

  deleteByItemId(id: number) {
    this.delCartItemsub = this.CartService.deleteCartitem(id).subscribe({
      next: (data) => {
        console.log('delete succesful' + data);
        this.CartService.getNumberOfitemInCart();
        this.getcartbyId();
      },

      error: (e) => {
        console.log('ERROR when delete cartItem ' + e);
      },
    });
  }

  decreasecartItem(productId: number, quantity: number) {
    this.lastitemChange = productId;
    if (quantity > 1) {
      this.waitUpdatNumber = true;
      this.isMaxThanAvailable = false;
      const updatecart: Uppdatecart = {
        state: 0,
        quantity: quantity - 1,
      };

      this.updateCartItemsub = this.CartService.updateCartItem(
        this.customerID,
        productId,
        updatecart
      ).subscribe({
        next: (data) => {
          console.log('increased quantity');

          this.getcartbyId();
        },

        error: (e) => {
          console.log('Error when Update' + e);
          this.waitUpdatNumber = false;
          this.getcartbyId();
        },
      });
    } else {
      this.isZero = true;
    }
  }
  increasecartItem(productId: number, quantity: number) {
    this.lastitemChange = productId;
    this.waitUpdatNumber = true;
    this.isZero = false;
    const updatecart: Uppdatecart = {
      state: 0,
      quantity: quantity + 1,
    };
    console.log(this.customerID);
    console.log(productId);
    console.log(updatecart);
    this.updateCartItemsub = this.CartService.updateCartItem(
      this.customerID,
      productId,
      updatecart
    ).subscribe({
      next: (data) => {
        console.log('increased quantity');
        this.getcartbyId();
      },

      error: (e) => {
        console.log('Error when Update' + e);
        this.isMaxThanAvailable = true;
        this.waitUpdatNumber = false;
        this.getcartbyId();
      },
    });
  }

  assignToCheckoutForm(){
    this.nameProductVarient = [];
    this.productVarientperOrder = [];
    for (var item of this.cart.items){
      let PVI: IproductforOrderadd = {
        productVarientId: item.productVarientId,
        quantity: item.quantity,
        totalCost: item.unitPrice * item.quantity,
      };
      this.productVarientperOrder.push(PVI);
      this.nameProductVarient.push(item.name);
      this.totalPrice = this.cart.totalPrice;
    }
  }

  //   gotoCheckout() {
  //     this.CartService.getNumberOfitemInCart();
  //     let length : number = this.cart.items.length;
  //     for (let i = 0; i < this.cart.items.length ; ) {
  //        let item = this.cart.items[i]
  //       const updatecart: Uppdatecart = {
  //         state: 1,
  //         quantity: item.quantity,
  //       };
  //       this.updateCartItemsub = this.CartService.updateCartItem(
  //         this.customerID,
  //         item.productVarientId,
  //         updatecart
  //       ).subscribe({
  //         next: (data) => {
  //           console.log('done go to checkOut');
  //           if( i == length-1){
  //             this._Router.navigate(['/checkout']);
  //           }else{
  //             i++
  //           }
  //         },

  //         error: (e) => {
  //           console.log('Error when go to CheckOut' + e);
  //           this.getcartbyId();
  //         },
  //       });
  //     }
  //   }


  SendOrder(e: Event) {
    if (this.registerForm.valid) {
      this.waitingSendOrder = true;
      this.btnText = '';
      const order: IorderAdd = {
        customerId: this.customerID,
        orderDate: new Date().toISOString(),
        customerAddress:`${this.registerForm.get('Governorate')?.value},${this.registerForm.get('place')?.value},${this.registerForm.get('residential_area')?.value}` ,
        productsperOrder: this.productVarientperOrder,
      };
      console.log(order);
      this.orderSer.addorder(order).subscribe({
        next: (data) => {
          console.log('done' + data);
          this.deleteafterCheckout2();
        },
        error: (e) => {
          console.log('error when send order', e);
          // this.errorOrder = true;
          
        },
      });
      
    } else {
      this.showerror = true;
    }
  }

//   deleteafterCheckout2() {
//     console.log("we are now in delete");
//     let length : number = this.cart.items.length;
//     for (let i = 0; i < length;) {
//       let item = this.cart.items[i];
//       console.log("no gonna delete",item);
//       this.deletecartAfCheckSub = this.CartService.deleteCartitem(
//         item.id
//       ).subscribe({
//         next: () => {
//           console.log('Delete success ');
//           if (i == length-1)
//           {
//             this.doneOrder = true;
//             this.waitingSendOrder = false;
//             this.CartService.getNumberOfitemInCart();
//           }
//           else{
//             i++
//           }
//         },
//         error: (e) => {
//           i++;
//           console.log('ERROR when delete', e);
//         },
//       });
//     }
//   }

deleteafterCheckout2() {
  console.log("we are now in delete");
  let length: number = this.cart.items.length;
  let successfulDeletions = 0; // Track successful deletions

  for (let i = 0; i < length; i++) {
    let item = this.cart.items[i];
    console.log("no gonna delete", item);
    this.deletecartAfCheckSub = this.CartService.deleteCartitem(item.id).subscribe({
      next: () => {
        console.log('Delete success ');
        successfulDeletions++; // Increment successful deletion count

        // Check if all items have been successfully deleted
        if (successfulDeletions === length) {
          this.doneOrder = true;
          this.waitingSendOrder = false;
          this.getcartbyId();
          this.CartService.getNumberOfitemInCart();
        }
      },
      error: (e) => {
        console.log('ERROR when delete', e);
        // Handle error appropriately, e.g., display error message to the user
      },
    });
  }
}

}
