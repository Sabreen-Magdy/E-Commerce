import { Component } from '@angular/core';
import { AuthService } from 'src/app/auth.service';
import { CartService } from 'src/app/services/cart.service';
import { FavoriteService } from 'src/app/services/favorite.service';

@Component({
  selector: 'app-navbar2',
  templateUrl: './navbar2.component.html',
  styleUrls: ['./navbar2.component.css']
})
export class Navbar2Component {
  showMenu: boolean = false;
  isCustomer: boolean = false;
  numOfItemInFavCart:number=0;
  numOfItemInCart:number=0;
  constructor(private _AuthService:AuthService,private _favservice:FavoriteService,private cartService:CartService){
    this._favservice.getNumberOfitemInFavCart();
    this.cartService.getNumberOfitemInCart();
  }
  ngOnInit():void{
    this._AuthService.userData.subscribe({
      next:()=>{
        if(this._AuthService.userData.getValue()!=null){
          this.isCustomer=true;
        }else{
          this.isCustomer=false;
        }
      }
    });
    this._favservice.numberOfitemInFavCart.subscribe({
      next:()=>{
         this.numOfItemInFavCart=this._favservice.numberOfitemInFavCart.getValue();
      }
    });
    this.cartService.numberOfitemInCart.subscribe({
      next:()=>{
         this.numOfItemInCart=this.cartService.numberOfitemInCart.getValue();
      }
    });
  }

  toggleMenu(): void {
    this.showMenu = !this.showMenu;
  }

  logOut(){
    this._AuthService.signOut()
  }

}
