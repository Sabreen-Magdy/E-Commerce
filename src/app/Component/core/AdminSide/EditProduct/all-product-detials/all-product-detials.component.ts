import { IcoloredImage, IProductDetilas, IVarient } from './../../../../../models/edit-product';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { EditProductService } from 'src/app/services/edit-product.service';

@Component({
  selector: 'app-all-product-detials',
  templateUrl: './all-product-detials.component.html',
  styleUrls: ['./all-product-detials.component.css']
})
export class AllProductDetialsComponent implements OnInit {

  constructor( private editServ : EditProductService, private _router : Router , private actRoute: ActivatedRoute) {}
  
  productId: number = 0;
  detilasObject : IProductDetilas = {
    id: 0,
    name: '',
    avgRating: 0,
    numberReviews: 0,
    description: ''
  }
  coloredProduct : IcoloredImage[] = [];
  variantProduct :IVarient[] = [];

  getStarArray(count: number): any[] {
    return Array(count).fill(0);
  }

  ngOnInit(): void {
    this.productId = this.actRoute.snapshot.params['id'];
    this.getAllDetials();
    this.getAllColoredProd();
    this.getAllVariant();
  }

  getDetialsSub : Subscription | undefined;
  getVariantSub : Subscription | undefined;
  getColoredProdSub : Subscription | undefined;
  

  deleteVariantSub : Subscription | undefined;
  deleteColoredProdSub : Subscription | undefined;


  getAllDetials(){
    this.getDetialsSub = this.editServ.getonlyDetailsById(72).subscribe(
      {
        next: (data) => {
          this.detilasObject = data
        },
        error: (e) => {
          console.log("ERROR when fetch Detials");
          console.log(e);
        }
      })
  }

  getAllColoredProd(){
    this.getColoredProdSub = this.editServ.getProductImages(72).subscribe(
      {
        next: (data) => {
          this.coloredProduct = data
        },
        error: (e) => {
          console.log("ERROR when fetch colored Prod");
          console.log(e);
        }
      })
  }
  getAllVariant(){
    this.getVariantSub = this.editServ.getVariantsById(72).subscribe(
      {
        next: (data) => {
          this.variantProduct = data
        },
        error: (e) => {
          console.log("ERROR when fetch Detials");
          console.log(e);
        }
      })
  }


  deleteColoredProd(id : number){
    this.deleteColoredProdSub = this.editServ.deleteProductImages(id).subscribe({
      next: (d)=>{
        console.log(d);
        this.getAllColoredProd();
        this.getAllVariant();
      },
      error: (e) =>{
        console.log("ERROR when delete product Image");
        console.log(e);
      }
    })
  }
  deleteVariantProd(id : number){
    this.deleteVariantSub = this.editServ.deleteVariant(id).subscribe({
      next: (d)=>{
        console.log(d);
        this.getAllVariant();
      },
      error : (e) => {
        console.log("ERROR when delete product variant");
        console.log(e);
      }
    })
  }
}


