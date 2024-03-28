import { ProductService } from './../../../services/product.service';
import { IproductShow } from './../../../models/i-product-variant';
import { Component, OnInit } from '@angular/core';
import { ComponentUrl } from 'src/app/models/unit';
import { Subscription } from 'rxjs';
import { ProductFormService } from 'src/app/services/product-form.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from 'src/app/services/category.service';
import { ICategory } from 'src/app/models/i-category';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css'],
})
export class StoreComponent implements OnInit {
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

  constructor( private _Router:Router, private prodServ:ProductFormService, private cateServ : CategoryService , private activeRoute:ActivatedRoute ){}
  ngOnInit(): void {
    this.getAllCategory();
    console.log("start");
    this.activeRoute.params.subscribe(params => {
      this.categoryName = params['catgoryname'];
      this.productName = params ['productname']
      console.log(this.categoryName); // Convert the parameter to a number
      if (this.categoryName)
      {
        console.log("cate");
        this.getAllproductByCat()
      } else if (this.productName){
        console.log("product");
        this.getproductByName();    
      }
      else{
        console.log('all');
        this.getAllProduct();
        
      }
    })

    // this.getAllProduct();
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
