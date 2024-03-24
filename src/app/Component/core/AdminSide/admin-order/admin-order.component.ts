import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-order',
  templateUrl: './admin-order.component.html',
  styleUrls: ['./admin-order.component.css']
})
export class AdminOrderComponent {

  toggleModel(){
    var model = document.getElementById("orderForm");
    model?.classList.add("model-show")
  }

  closeModel(){
    var model = document.getElementById("orderForm");
    model?.classList.remove("model-show")
  }
}
