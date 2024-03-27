import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IproductShow } from 'src/app/models/i-product-variant';
import { ProductFormService } from 'src/app/services/product-form.service';

@Component({
  selector: 'app-product-tabel',
  templateUrl: './product-tabel.component.html',
  styleUrls: ['./product-tabel.component.css']
})
export class ProductTabelComponent implements OnInit {

  productList : IproductShow[] = [];

  constructor( private prodServ:ProductFormService ){}
  ngOnInit(): void {
    this.getallProduct();
  }

  allProductSub : Subscription | undefined;

  getallProduct(){
    this.allProductSub = this.prodServ.getAllProduct().subscribe({
      next:(data) => {
        console.log(data);
        this.productList=data;
      } ,
      error:(e) => {
        console.log("ERROR: " + e);
      }
    })
  }

  deleteProduct (id : number) {
    this.prodServ.deleteProduct(id).subscribe({
      next: ()=> {this.getallProduct();},
      error: (e) => {
        console.log("ERROR When delete product" + e);
      }
    })
  }



}
