import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IproductShow } from 'src/app/models/i-product-variant';
import { ProductFormService } from 'src/app/services/product-form.service';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css']
})
export class NewProductComponent implements OnInit {

  allproductList :IproductShow[] =[];

  constructor( private prodServ : ProductFormService ){}

  ngOnInit(): void {
    this.getallproduct();
  }

  AllProductSub : Subscription | undefined;

  getallproduct(){
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

  
}
