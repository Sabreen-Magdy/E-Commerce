import { ProductService } from './../../../services/product.service';
import { IproductShow } from './../../../models/i-product-variant';
import { Component, OnInit } from '@angular/core';
import { ComponentUrl } from 'src/app/models/unit';
import { Subscription } from 'rxjs';
import { ProductFormService } from 'src/app/services/product-form.service';
import { ActivatedRoute } from '@angular/router';

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
  categoryName : string = "";

  constructor( private prodServ:ProductFormService, private activeRoute:ActivatedRoute ){}
  ngOnInit(): void {
    this.activeRoute.params.subscribe(params => {
      this.categoryName = params['productDetials']; // Convert the parameter to a number
      if (this.categoryName != ""){
        this.allProdbyCatSub
      }else(this.getAllProduct)
    })
  }

  allProductSub : Subscription | undefined;
  allProdbyCatSub : Subscription | undefined;

  
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
}
