import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth.service';
import { Ifav } from 'src/app/models/Ifav';
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


  pushItemToFavCart(id:number,image:string,name:string,price:number){
    console.log(image);
    let favoriteItem : Ifav = {
      CustomerId:this.customerId,
      ProductId :id,
      Image :image,
      Name:name,
      Description :"ffff",
      Price :price
  }
    this._favService.addToFavorite(favoriteItem);
  }
}
