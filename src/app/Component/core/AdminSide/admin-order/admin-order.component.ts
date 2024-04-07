import { AdminOrder } from './../../../../models/admin-order';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AdminOrderService } from 'src/app/services/admin-order.service';

@Component({
  selector: 'app-admin-order',
  templateUrl: './admin-order.component.html',
  styleUrls: ['./admin-order.component.css']
})
export class AdminOrderComponent implements OnInit {
  p:number = 1;
  waiting : boolean = true;
  noitem : boolean = false;

  constructor(private adminser: AdminOrderService) { }
  orders: AdminOrder[] = [];
  basicOrder : AdminOrder [] = [];
  RefuseForm: FormGroup = new FormGroup({
    ReasonOrder: new FormControl('', [Validators.required, Validators.pattern('[\u0600-\u06FF ,]+'), Validators.minLength(5)]),
  })

  get Reasonproductcontrol() {
    return this.RefuseForm.get('ReasonOrder')
  }

  ngOnInit(): void {
    this.adminser.getAll().subscribe({
      next: (data) => {
        this.waiting = false;
        if (data.length ==0 ){
          this.noitem = true; 
        }
        data.sort((a,b)=>b.orderId-a.orderId);
        this.orders = data;
        this.basicOrder = data;
        console.log(this.orders)
        //console.log(this.orders[0].customerName)
        for (let index = 0; index < this.orders.length; index++) {
          //  const element = array[index];
          if (this.orders[index].state == 3) {
            this.orderStateAOrR[index] = 1
          }
          else {
            this.orderStateAOrR[index] = this.orders[index].state
          }

        }
      }, 
      error : (e) => {
        console.log("ERROR");
        console.log(e);
        this.noitem = true;
      }
    })

  }
  selectedIndex: number = 0
  orderStateAOrR: number[] = []
  orderStateDeliver: number[] = []

  toggleModel(index: number) {
    console.log(index);
    var model = document.getElementById("orderForm");
    model?.classList.add("model-show")
    this.selectedIndex = index ;
    console.log(this.selectedIndex);
  }

  closeModel() {
    var model = document.getElementById("orderForm");
    model?.classList.remove("model-show")
  }
  closeRefuse() {

    var model = document.getElementById("RefuceReason");
    model?.classList.remove("model-show")

  }
  accepted: boolean = false
  rejected: boolean = false
  AcceptOrder(order: AdminOrder, index: number) {
    this.adminser.UpdateStatus(order.orderId, 1,"تم قبول طلبك من قبل الادمن سيصلك المنتج خلال ايام قليله").subscribe({
      next: () => {
        order.state = 1;
        order.comment='تم قبول طلبك من قبل الادمن سيصلك المنتج خلال ايام قليله'
        //order.accepted = false;
        this.orderStateAOrR[index] = 1
      },
      error: (error) => {
        console.error('Error rejecting order:', error);
      }
    })
    this.accepted = true
  }
  RegectOrder(order: AdminOrder, index: number) {
    var model = document.getElementById("RefuceReason");
    model?.classList.add("model-show")
    this.selectedIndex = index

  }
  submitRefuse(event: Event) {
    event.preventDefault()
    this.adminser.UpdateStatus(this.orders[this.selectedIndex].orderId, 2,this.RefuseForm.get('ReasonOrder')?.value).subscribe({
      next: () => {
        this.orders[this.selectedIndex].state = 2;
        //order.accepted = false;
        this.orderStateAOrR[this.selectedIndex] = 2
      },
      error: (error) => {
        console.error('Error rejecting order:', error);
      }
    })
    this.closeRefuse()


    //this.rejected = true
  }
  DeliverOrder(order: AdminOrder, index: number) {
    this.adminser.UpdateStatus(order.orderId, 3,'تم تسليم طلبك تشرفنا بزيارتك لموقعنا').subscribe({
      next: () => {
        order.state = 3;
        //order.accepted = false;
        this.orderStateAOrR[index] = 1
      },
      error: (error) => {
        console.error('Error rejecting order:', error);
      }
    })
  }



  getIndex(i: number) {
    let pageCorrection: number;
    let indexPerPage = 10;
    if (this.p === 1) {
      pageCorrection = 0;
    } else {
      pageCorrection = (this.p - 1) * indexPerPage;
    }
    return i + 1 + pageCorrection;
  }


  sortOrderList(e:Event){
    this.p=1;
    let option = (e.target as HTMLInputElement).value;
    switch (option) {
      case '-1':
        this.orders = this.basicOrder;
        this.orderStateAOrR = this.orders.map(order => order.state == 3 ? 1 : order.state);
        break;
      case '0':
      case '1':
      case '2':
      case '3':
        this.orders = this.basicOrder.filter(a => a.state == parseInt(option));
        // Update orderStateAOrR array to reflect the changes
        this.orderStateAOrR = this.orders.map(order => order.state == 3 ? 1 : order.state);
        break;
      default:
        this.orders = this.basicOrder;
        this.orderStateAOrR = this.orders.map(order => order.state == 3 ? 1 : order.state);
        break;
    }
  }
  
}
