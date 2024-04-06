import { Component } from '@angular/core';
import { AuthService } from 'src/app/auth.service';
import { CartService } from 'src/app/services/cart.service';
import { FavoriteService } from 'src/app/services/favorite.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent {
  constructor(private favService:FavoriteService,private _cart:CartService){}
  ngOnInit(){
    this._cart.getNumberOfitemInCart();
    this.favService.getNumberOfitemInFavCart();
  }
}
