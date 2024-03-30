import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth.service';
import { CartItemDto, Uppdatecart } from 'src/app/models/icart';
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
  noitem:boolean = false;
  wiating:boolean = false;
  doneOrder : boolean = false;
  checkoutForm : FormGroup;
  btnText :string = "الاستمرار في تأكيد الطلب"
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

  cartByIDsub : Subscription | undefined;
  deletecartAfCheckSub : Subscription | undefined;




  get mainaddresscontrol(){
    return this.checkoutForm.get('mainaddress')
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
       if( this.productVarientperOrder.length == 0){
        this.noitem = true
       }
      },
      error : (e) =>{
        this.noitem = true;
        console.log("ERROR when fetch Data of CartItem" + e);
      }
    })
  }




   SendOrder(e:Event){

    console.log(new Date().toISOString());
      if (this.checkoutForm.valid){
        this.wiating = true;
        this.btnText= "";
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
            this.doneOrder = true;
            this.deleteafterCheckout2();
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
