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
  customerID : number = 0;
  cart : CartDto = {
    totalPrice: 0,
    totalQuantity: 0,
    items: []
  };

  constructor( private CartService: CartService, private authServ : AuthService ){}
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
        this.cart.items = this.cart.items.filter((item)=>item.state==0);
        this.cart.totalPrice = totalPriceS;
        console.log("cart" ,this.cart);
      },
      error : (e) =>{
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



}
