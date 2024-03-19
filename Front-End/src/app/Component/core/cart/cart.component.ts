import { Component } from '@angular/core';
import { ComponentUrl } from 'src/app/models/unit';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {
  ComponentUrl=ComponentUrl;
}
