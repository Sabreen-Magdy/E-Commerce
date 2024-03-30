import { Router } from '@angular/router';
import { Uppdatecart } from './../../../models/icart';
import { CartService } from './../../../services/cart.service';
import { Component, OnInit } from '@angular/core';
import { filter, Subscribable, Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth.service';
import { CartDto, CartItemDto } from 'src/app/models/icart';
import { ComponentUrl } from 'src/app/models/unit';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  ComponentUrl=ComponentUrl;
  buttonText:string= "تأكيد الطلب" 
  customerID : number = 0;
  cart : CartDto = {
    totalPrice: 0,
    totalQuantity: 0,
    items: []
  };

  noitem : boolean = false;
  wiating : boolean = false;

  constructor( private CartService: CartService, private authServ : AuthService , private _Router:Router){}
  ngOnInit(): void {
    this.customerID = this.authServ.id;
    this.getcartbyId()
    this.CartService.getNumberOfitemInCart();
  }

  cartByIDsub : Subscription | undefined;
  delCartItemsub : Subscription | undefined;
  updateCartItemsub : Subscription | undefined;

  getcartbyId(){
    console.log('dkdkd');
    console.log(this.customerID);
    this.cartByIDsub = this.CartService.getCartBycstId(this.customerID).subscribe({
      next : (data) =>{
        let filterdata = data.items.filter((item)=>item.state==0);
        let totalPriceS : number = 0;
        // this.cart.items = this.cart.items.filter((item)=>item.state==0)
        for (var item of filterdata){
          totalPriceS += item.unitPrice * item.quantity
        }
        this.cart = data;
        this.cart.items = filterdata;
        this.cart.totalPrice = totalPriceS;
        console.log("cart" ,this.cart);
        if (filterdata.length == 0){
          this.noitem = true;
        }
      },
      error : (e) =>{
        this.noitem = true;
        console.log("ERROR when fetch Data of CartItem" + e);
      }
    })
  }

  deleteByItemId(id : number){
    this.delCartItemsub = this.CartService.deleteCartitem(id).subscribe({
      next : (data) => {
        console.log("delete succesful" + data);
       this.CartService.getNumberOfitemInCart();
        this.getcartbyId()
      },

      error : (e) => {
        console.log("ERROR when delete cartItem " + e);
      }
    })
  }


  decreasecartItem (productId : number, quantity : number ){

    const updatecart :Uppdatecart = {
      state: 0,
      quantity: quantity - 1
    }
    console.log(this.customerID);
    console.log(productId);
    console.log(updatecart);
    this.updateCartItemsub = this.CartService.updateCartItem(this.customerID,productId,updatecart).subscribe({
      next : (data) => {
        console.log("increased quantity");
        this.getcartbyId();
      },

      error : (e)=>{
        console.log("Error when Update" + e);
        this.getcartbyId();
      }
    })
  }
  increasecartItem (productId : number, quantity : number ){

    const updatecart :Uppdatecart = {
      state: 0,
      quantity: quantity +1
    }
    console.log(this.customerID);
    console.log(productId);
    console.log(updatecart);
    this.updateCartItemsub = this.CartService.updateCartItem(this.customerID,productId,updatecart).subscribe({
      next : (data) => {
        console.log("increased quantity");
        this.getcartbyId();
      },

      error : (e)=>{
        console.log("Error when Update" + e);
        this.getcartbyId();
      }
    })
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

gotoCheckout() {
  this.buttonText = ""
  this.wiating = true;
  // Call CartService to get the number of items in the cart
  this.CartService.getNumberOfitemInCart() ;
    // Get the length of cart items
    let length: number = this.cart.items.length;

    // Check if cart has items
    if (length > 0) {
      // Initialize index
      let i = 0;

      // Iterate through cart items
      for (const item of this.cart.items) {
        const updatecart: Uppdatecart = {
          state: 1,
          quantity: item.quantity,
        };

        // Update cart item
        this.updateCartItemsub = this.CartService.updateCartItem(
          this.customerID,
          item.productVarientId,
          updatecart
        ).subscribe({
          next: (e) => {
            // Log success message
            console.log('Item updated successfully.');
            console.log(i);
            console.log(e);
            // Check if it's the last item
            if (i == length - 1) {
              this.CartService.getNumberOfitemInCart() ;
              // Navigate to checkout page
              console.log("we are gonna go");
              this._Router.navigate(['/checkout']);
            } else {
              
              // Increment index
              i++;

              console.log("increament" , i);
            }
          },
          error: (e) => {
            // Log error and reload cart
            console.log('Error when updating item: ' + e);
            if (i == length - 1) {
              this.wiating = false;
              this.getcartbyId();
            }
            
          },
        });
      }
    } else {
      // Cart is empty, do something (e.g., display message)
    }
  
}


}
