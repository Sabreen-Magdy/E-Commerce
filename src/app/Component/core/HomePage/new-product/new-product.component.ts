import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth.service';
import { IaddFavorite, Ifav } from 'src/app/models/Ifav';
import { IproductShow } from 'src/app/models/i-product-variant';
import { FavoriteService } from 'src/app/services/favorite.service';
import { ProductFormService } from 'src/app/services/product-form.service';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css']
})
export class NewProductComponent implements OnInit {

  allproductList :IproductShow[] =[];
  customerId:number=0;
  constructor( private prodServ : ProductFormService,private _authService:AuthService,private _favService:FavoriteService){}

  ngOnInit(): void {
    this.customerId=this._authService.id;
    this.getallproduct();
  }

  AllProductSub : Subscription | undefined;
  addFavSub : Subscription | undefined;
  getallproduct(){
    console.log("doooone");
    this.AllProductSub = this.prodServ.getAllProduct().subscribe({
      next : (data) => {
        console.log("doooone");
        this.allproductList = data;
      },
      error : (e) => {
        console.log("Error when fetch Data" + e);
      }
    })
  }

  pushItemToFavCart( prodId : number ){
    const addFav : IaddFavorite = {
      customerId: this.customerId,
      productId: prodId
    }

   this.addFavSub = this._favService.additemTofav(addFav).subscribe({
    next : (data) => {
      console.log("item Add to Fav Succesfully" + data);
    },
    error : (e) => {
      console.log("may bt item in fav already");
      console.log("ERROR when add fav to item" + e);
    }
   }) 
  }


  
}
