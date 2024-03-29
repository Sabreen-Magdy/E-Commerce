import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth.service';
import { CartDto, CartItemDto, Uppdatecart } from 'src/app/models/icart';
import { IorderAdd, IproductforOrderadd } from 'src/app/models/order';
import { addorderService } from 'src/app/services/AddOrder.service';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent  implements OnInit {
  showerror : boolean = false;
  customerID : number = 0;
  checkoutForm : FormGroup;
  numOfItemInCart:number=0;
  cart : CartDto = {
    totalPrice: 0,
    totalQuantity: 0,
    items: []
  };
  cartByIDsub : Subscription | undefined;
  productVarientperOrder : IproductforOrderadd[] = [];
  nameProductVarient : string[] =[];
  cartitemfordelete : CartItemDto [] = [];
  totalPrice : number =0;
  constructor( private auth: AuthService, private orderSer:addorderService , private CartService:CartService){
    this.checkoutForm = new FormGroup({
      mainaddress : new FormControl (
        "",
        [
          Validators.required,
          Validators.minLength(10),
          Validators.pattern('[\u0600-\u06FF ,]+')
        ]
      ),


    }
    );
  }
  ngOnInit(): void {
    this.customerID = this.auth.id;
    this.getcartbyId();
  }

  deletecartAfCheckSub : Subscription | undefined;

  get mainaddresscontrol(){
    return this.checkoutForm.get('mainaddress')
  }

  enter(e:Event){
    console.log(this.checkoutForm.valid);
   }

   deleteafterCheckout() {
    for (let item of this.productVarientperOrder) {
      this.deletecartAfCheckSub = this.CartService.deleteCartItemByCID(this.customerID,item.productVarientId).subscribe({
        next: ()=>{
          console.log("Delete success ");
        },
        error: (e)=>{
          console.log("ERROR when delete",e);
        }
      })

    }
  }

  deleteafterCheckout2() {
    for (let item of this.cartitemfordelete) {
      this.deletecartAfCheckSub = this.CartService.deleteCartitem(item.id).subscribe({
        next: ()=>{
          console.log("Delete success ");
        },
        error: (e)=>{
          console.log("ERROR when delete",e);
        }
      })

    }
  }
   getcartbyId(){
    console.log('dkdkd');
    console.log(this.customerID);
    this.cartByIDsub = this.CartService.getCartBycstId(this.customerID).subscribe({
      next : (data) =>{
        let filterdata = data.items.filter((item)=>item.state==1);
        let totalPriceS : number = 0;
        for (var item of filterdata){
          totalPriceS += item.unitPrice * item.quantity
          let PVI : IproductforOrderadd ={
            productVarientId: item.productVarientId,
            quantity: item.quantity,
            totalCost: item.unitPrice * item.quantity
          }
          this.productVarientperOrder.push(PVI);
          this.nameProductVarient.push(item.name)

        }
        this.totalPrice = totalPriceS;
        this.cartitemfordelete = filterdata;

      },
      error : (e) =>{
        console.log("ERROR when fetch Data of CartItem" + e);
      }
    })
  }



   SendOrder(e:Event){
    console.log(new Date().toISOString());
      if (this.checkoutForm.valid){

        const order : IorderAdd = {
          customerId: this.customerID,
          orderDate: new Date().toISOString(),
          customerAddress: this.checkoutForm.get('mainaddress')?.value,
          productsperOrder: this.productVarientperOrder
        }
        console.log(order);
        this.orderSer.addorder(order).subscribe({
          next: (data) => {
            console.log("done"+data);
            this.deleteafterCheckout();
            this.getcartbyId();
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
