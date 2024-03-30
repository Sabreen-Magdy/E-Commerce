import { DashboardService } from './../../../../services/dashboard.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {
  icon = 'face';
  fontSize = '24px';
  iconColor = 'red';

  ordersnum:number=0
  customernum:number=0
  productsnum:number=0
  profit:number=0
  constructor(private dashserv: DashboardService){}
  ngOnInit(): void {
    this.dashserv.getOrderNum().subscribe({
      next:(data)=>this.ordersnum= data
    })

    this.dashserv.getCustomerNum().subscribe({
      next:(data)=>this.customernum= data
    })

    this.dashserv.getProfit().subscribe({
      next:(data)=>this.profit= data
    })
    this.dashserv.getProductNum().subscribe({
      next:(data)=>this.productsnum= data
    })
  }

}
