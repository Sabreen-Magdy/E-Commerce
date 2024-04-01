import { customerOrder } from './../../../../models/customerOrder';
import { Component } from '@angular/core';
import { AuthService } from 'src/app/auth.service';


interface orderDetials {
  totalCost :string,
  address:string,
  date :string,
  status:string,
  orderI:string
}

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.css']
})
export class ActivityComponent {
  processedData: customerOrder[] = [];
  selectedIndex :number = 1
  p:number =1;
  constructor(private _AuthService:AuthService){}
  ngOnInit(): void {
    this._AuthService.userData.subscribe({
      next:()=>{
        if(this._AuthService.userData.getValue()!=null){
          this._AuthService.getOrderOfUser().subscribe({ 
            next:(response)=> {
              // this.processedData = response;
              for (var item of response){
                let dateObj = new Date(item.orderDate);
                let formattedDate = dateObj.toISOString().split('T')[0].replace(/-/g, '/');
                item.orderDate = formattedDate;
              } 
              this.processedData = response;
              // console.log(response[0].orderDate);
              // console.log(typeof(response[0].orderDate));
              // this.processedData = response.map(order => {
              //   let dateObj = new Date(order.orderDate);
              //   let formattedDate = dateObj.toISOString().split('T')[0].replace(/-/g, '/');
              //   return {
              //     totalCost: order.orderTotalCost,
              //     address: order.customerAddress,
              //     date: formattedDate,
              //     status: order.state === 0 ? "تم رفضه" : "يتم تجهيزه",
              //     orderId: order.orderId
              //   };
              // });
          }
        });
        }
      }
    });
  }

  stringState(s: number): string {
    if (s == 0){
      return 'يُرجى الانتظار بينما يقوم البائع بمراجعة طلبك واتخاذ قرار بشأن قبوله أو رفضه'
    }else if (s == 1){
      return 'تم قبول طلبك من قبل الادمن سيصلك المنتج خلال ايام قليله'
    }else if (s == 2){
      return 'تم رفض طلبك'
    }
    return 'تم تسليم طلبك تشرفنا بزيارتك لموقعنا'
  }

  toggleModel(index :number){
    var model = document.getElementById("orderForm");
    model?.classList.add("model-show")
    this.selectedIndex = index
  }

  closeModel(){
    var model = document.getElementById("orderForm");
    model?.classList.remove("model-show")
  }
}
