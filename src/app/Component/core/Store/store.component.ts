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

  constructor( private _Router:Router, private prodServ:ProductFormService, private cateServ : CategoryService , private activeRoute:ActivatedRoute ,private auth :AuthService){}
  
  ngOnDestroy(): void {
    
  }
  ngOnInit(): void {
    // this.getAllCategory();
    console.log("start");
    // this.activeRoute.params.subscribe(params => {
    //   this.categoryName = params['catgoryname'];
    //   this.productName = params ['productname']
    //   console.log(this.categoryName); // Convert the parameter to a number
    //   if (this.categoryName)
    //   {
    //     console.log("cate");
    //     this.getAllproductByCat()
    //   } else if (this.productName){
    //     console.log("product");
    //     this.getproductByName();    
    //   }
    //   else{
    //     console.log('all');
    //     this.getAllProduct();
        
    //   }
    // })

    // this.getAllProduct();
    // console.log("init")
    // console.log(this.auth.allProducts);
    // this.ProductList = this.auth.allProducts;

  // this.prodServ.getAllProduct2();
  // this.ProductList = this.prodServ.productsCache;
  this.prodServ.getAllProduct2().subscribe(
    products => {
      this.ProductList = products;
    },
    error => {
      console.error('Error fetching products:', error);
    }
  );
    
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
        console.log("producrLisr" + this.ProductList);
      },
      error : (e) => {
        console.log("ERROR when fetch DataByName"+e);
      }
    })
  }
}
