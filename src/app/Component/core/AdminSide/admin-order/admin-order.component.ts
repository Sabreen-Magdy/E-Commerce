import { AdminOrder } from './../../../../models/admin-order';
import { Component, OnInit } from '@angular/core';
import { AdminOrderService } from 'src/app/services/admin-order.service';

@Component({
  selector: 'app-admin-order',
  templateUrl: './admin-order.component.html',
  styleUrls: ['./admin-order.component.css']
})
export class AdminOrderComponent implements OnInit {


  constructor(private adminser: AdminOrderService) { }
  orders: AdminOrder[] = []

  ngOnInit(): void {
    this.adminser.getAll().subscribe({
      next: (data) => {
        this.orders = data;
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
      }
    })

  }
  selectedIndex: number = 0
  orderStateAOrR: number[] = []
  orderStateDeliver: number[] = []

  toggleModel(index: number) {
    var model = document.getElementById("orderForm");
    model?.classList.add("model-show")
    this.selectedIndex = index
  }

  closeModel() {
    var model = document.getElementById("orderForm");
    model?.classList.remove("model-show")
  }

  accepted: boolean = false
  rejected: boolean = false
  AcceptOrder(order: AdminOrder, index :number) {
    this.adminser.UpdateStatus(order.orderId, 1).subscribe({
      next: () => {
        order.state = 1;
        //order.accepted = false;
        this.orderStateAOrR[index]=1
      },
      error: (error) => {
        console.error('Error rejecting order:', error);
      }
    })
    this.accepted = true
  }
  RegectOrder(order: AdminOrder,index:number) {
    this.adminser.UpdateStatus(order.orderId, 2).subscribe({
      next: () => {
        order.state = 2;
        //order.accepted = false;
        this.orderStateAOrR[index]=2
      },
      error: (error) => {
        console.error('Error rejecting order:', error);
      }
    })
    this.rejected = true
  }
  DeliverOrder(order:AdminOrder,index:number){
    this.adminser.UpdateStatus(order.orderId, 2).subscribe({
      next: () => {
        order.state = 4;
        //order.accepted = false;
        this.orderStateAOrR[index]=1
      },
      error: (error) => {
        console.error('Error rejecting order:', error);
      }
    })
  }
}
