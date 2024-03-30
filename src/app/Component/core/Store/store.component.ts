import { ProductService } from './../../../services/product.service';
import { IproductShow } from './../../../models/i-product-variant';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ComponentUrl } from 'src/app/models/unit';
import { Subscription } from 'rxjs';
import { ProductFormService } from 'src/app/services/product-form.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from 'src/app/services/category.service';
import { ICategory } from 'src/app/models/i-category';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/auth.service';
import { SigninFormComponent } from '../SignComp/signin-form/signin-form.component';
import { FavoriteService } from 'src/app/services/favorite.service';
import { IaddFavorite } from 'src/app/models/Ifav';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css'],
})
export class StoreComponent implements OnInit , OnDestroy{
  ComponentUrl = ComponentUrl;
  toggle() {
    var blur = document.getElementById('blur');
    blur?.classList.toggle('active');
    var popup = document.getElementById('popup');
    popup?.classList.toggle('active');
  }

  /**fetch data */

  ProductList:IproductShow[] = [];
  categoryList : ICategory [] = [];
  categoryName : string = "";
  productName : string = "";
  customerId : number = 0;
  noitem : boolean = false;
  constructor( private _Router:Router, private prodServ:ProductFormService, private cateServ : CategoryService , private activeRoute:ActivatedRoute ,private auth :AuthService , private _favService:FavoriteService){}

  ngOnDestroy(): void {

  }
  ngOnInit(): void {
    console.log("length of store",this.ProductList.length);
    console.log("noitem",this.noitem);
    this.customerId=this.auth.id;
    this.prodServ.getlength();
    this.getAllCategory();
    console.log("start");
    this.activeRoute.params.subscribe(params => {
      this.categoryName = params['catgoryname'];
      this.productName = params ['productname']
      console.log(this.categoryName); // Convert the parameter to a number
      if (this.categoryName)
      {
        console.log(this.categoryName);
        this.prodServ.gatProductbyCategoryName2(this.categoryName).subscribe(
          products => {
            this.ProductList = products;
            if(this.ProductList.length == 0){
              this.noitem = true;
            }
          },
          error => {
            console.error('Error fetching products:', error);
            this.noitem = true;
          }
        );
      } else 
      if (this.productName){
        console.log("product");
        this.getproductByName();
      }
      else{
        this.prodServ.getAllProduct2().subscribe(
          products => {
            this.ProductList = products;
            if(this.ProductList.length == 0){
              this.noitem = true;
            }
          },
          error => {
            console.error('Error fetching products:', error);
            this.noitem = true;
          }
        );
      
      }
    })

    // this.getAllProduct();
    // console.log("init")
    // console.log(this.auth.allProducts);
    // this.ProductList = this.auth.allProducts;

  // this.prodServ.getAllProduct2();
  // this.ProductList = this.prodServ.productsCache;
  
  }


  nameSearchForm :FormGroup = new FormGroup ({
    name : new FormControl("",[Validators.required])
  })

  get nameControl(){
    return this.nameSearchForm.get('name')
  }

  enterName (e: Event) {
    e.preventDefault();
    if (this.nameSearchForm.valid){
      var name= this.nameSearchForm.get('name')?.value;
      this._Router.navigate([`store/products`,name]);
      this.toggle();
    }

  }
  allProductSub : Subscription | undefined;
  allProdbyCatSub : Subscription | undefined;
  prodByNameSub : Subscription | undefined;
  allCategorySub : Subscription | undefined;
  addFavSub : Subscription | undefined;
  getAllCategory(){
    this.allCategorySub = this.cateServ.getAllCategs().subscribe({
      next : (data) => {
        this.categoryList =data;
      },
      error : (e) => {
        console.log("ERROR when fetch Category :" + e);
      }
    })
  }

  getAllProduct(){
    this.allProductSub = this.prodServ.getAllProduct().subscribe({
      next: (data) => {
        this.ProductList = data
      },
      error : (e) => {
        console.log("Error when Fetch AllProduct" + e);
      }
    })
  }

  getAllproductByCat(){
    this.allProdbyCatSub = this.prodServ.gatProductbyCategoryName(this.categoryName).subscribe({
      next: (data) => {
        console.log(data);
        this.ProductList = data;
      },
      error : (e) => {
        console.log("error when fetch product BY Category" + e);
      }
    })
  }

  getproductByName (){
    this.prodByNameSub = this.prodServ.getProductByName(this.productName).subscribe({
      next : (data) => {
        console.log(data);
        this.ProductList = data;
        if(this.ProductList.length == 0){
          this.noitem = true
        }
        console.log("producrLisr" + this.ProductList);
      },
      error : (e) => {
        console.log("ERROR when fetch DataByName"+e);
        this.noitem = true;
      }
    })
  }

  pushItemToFavCart( prodId : number ){
    alert("Item added successfully!");
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
   this._favService.getNumberOfitemInFavCart();
  }
  
  sortProductList(e : any){
    let option = (e.target as HTMLInputElement).value;
    switch (option){
    case '2':
      this.ProductList.sort((a, b) => b.price - a.price);
      break;
    case '3':
      this.ProductList.sort((a, b) => a.price - b.price);
      break;
    case '4':
      this.ProductList.sort((a,b)=>b.addingDate.localeCompare(a.addingDate))
      break;
    case '5':
      this.ProductList.sort((a,b)=>b.avgRating - a.avgRating)
      break;
    default:
      // Default sorting logic (if no option is selected)
      break;
    }

  }
}

