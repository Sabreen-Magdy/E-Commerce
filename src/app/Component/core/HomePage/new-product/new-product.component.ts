import { Subscription } from 'rxjs';
import Swal from 'sweetalert2';
import { AuthService } from 'src/app/auth.service';
import { IaddFavorite } from 'src/app/models/Ifav';
import { IproductShow } from 'src/app/models/i-product-variant';
import { FavoriteService } from 'src/app/services/favorite.service';
import { ProductFormService } from 'src/app/services/product-form.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css']
})
export class NewProductComponent implements OnInit {

  allproductList :IproductShow[] =[];
  customerId:number=0;
  categoryName : string = "";
  thiscateg :boolean = false;
  constructor( private prodServ : ProductFormService,private _authService:AuthService,private _favService:FavoriteService , private activeRoute:ActivatedRoute , private route : Router){}

  ngOnInit(): void {
    this.customerId=this._authService.id;
    this.prodServ.getlength();
    this.activeRoute.params.subscribe(params => {
      this.categoryName = params['catgoryname'];
      console.log(this.categoryName); // Convert the parameter to a number
      if (this.categoryName)
      {
        this.thiscateg = true;
        console.log(this.categoryName);
        this.prodServ.gatProductbyCategoryName2(this.categoryName).subscribe(
          products => {
            products.sort((a,b)=>b.addingDate.localeCompare(a.addingDate))
            this.allproductList = products;
            
          },
          error => {
            console.error('Error fetching products:', error);
            
          }
        );
      } 
      
      else{
        this.prodServ.getAllProduct2().subscribe(
          products => {
            products.sort((a,b)=>b.addingDate.localeCompare(a.addingDate))
            this.allproductList = products;
            
            
          },
          error => {
            console.error('Error fetching products:', error);
            
          }
        );

      }
    })
 
  }

  AllProductSub : Subscription | undefined;
  addFavSub : Subscription | undefined;

  pushItemToFavCart( prodId : number ){
    Swal.fire({
      title: 'تم إضافة المنتج إلى قائمة أمنياتي',
      confirmButtonColor: '#198754', // Change this to the color you prefer
    });
    const addFav : IaddFavorite = {
      customerId: this.customerId,
      productId: prodId
    }

   this.addFavSub = this._favService.additemTofav(addFav).subscribe({
    next : (data) => {
      console.log("item Add to Fav Succesfully" + data);
      this._favService.getNumberOfitemInFavCart();
    },
    error : (e) => {
      console.log("may bt item in fav already");
      console.log("ERROR when add fav to item" + e);
    }
   })
   this._favService.getNumberOfitemInFavCart();
  }
  goto(){
    if (this.thiscateg){
     this.route.navigate([`/store/${this.categoryName}`])
    }else{
      this.route.navigate([`/store`])
    }
  }
}
