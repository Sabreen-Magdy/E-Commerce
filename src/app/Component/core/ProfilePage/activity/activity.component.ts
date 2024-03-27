import { Component } from '@angular/core';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.css']
})
export class ActivityComponent {
  processedData: any[] = [];
  constructor(private _AuthService:AuthService){}
  ngOnInit(): void {
    this._AuthService.userData.subscribe({
      next:()=>{
        if(this._AuthService.userData.getValue()!=null){
          this._AuthService.getOrderOfUser().subscribe(
            { next:(response:any[])=>{
              console.log(response)
              this.processedData = response.map(order => {
                return {
                  totalCost: order.orderTotalCost,
                  address: order.customerAddress,
                  date: order.orderDate,
                  status: order.state === 0 ? "تم رفضه" : "يتم تجهيزه",
                  orderId: order.orderId
                };
              });
          }
        });
        }
      }
    });
  }
}
