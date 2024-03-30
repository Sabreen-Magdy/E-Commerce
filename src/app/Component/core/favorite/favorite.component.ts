import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth.service';
import { favitem } from 'src/app/models/Ifav';
import { FavoriteService } from 'src/app/services/favorite.service';

@Component({
  selector: 'app-favorite',
  templateUrl: './favorite.component.html',
  styleUrls: ['./favorite.component.css']
})
export class FavoriteComponent {
  processedData: any[] = [];
  FavList : favitem[] = [];
  customerId:any;
  noitem : boolean = false;
 constructor(private _FavService:FavoriteService,private _AuthService:AuthService ){}
 ngOnInit(): void {
  this._AuthService.userData.subscribe({
    next:()=>{
      if(this._AuthService.userData.getValue()!=null){
        this.customerId=this._AuthService.id;
        console.log(this.customerId);
        this.getFavbyCId();
      }
    }
  });
  this._FavService.getNumberOfitemInFavCart();
  this._FavService.numberOfitemInFavCart.subscribe({
    next:()=>{
      this._FavService.numberOfitemInFavCart;
    }
  });
 }


 allFavByCustomerSub : Subscription | undefined;
 deleteFav : Subscription | undefined;

 getFavbyCId(){
  this.allFavByCustomerSub = this._FavService.getallFavbycustomr(this.customerId).subscribe({
    next : (data) => {
      console.log(data);
        this.FavList = data;
        if(data.length == 0) {
          this.noitem = true;
        }
    },
    error : (e) =>{
      console.log("ERROR", e);
      this.noitem = true;
    }
  })
 }

 deleteFavitem(prodid : number){
  this.deleteFav = this._FavService.deletefavitem(this.customerId,prodid).subscribe({
    next : (data) => {
      console.log("succesful delete: " + data);
      this._FavService.getNumberOfitemInFavCart();
      this.getFavbyCId();
    },
    error : (e)=>{
      console.log("ERROR when delete fav item" + e);
    }
  });
 }

}
