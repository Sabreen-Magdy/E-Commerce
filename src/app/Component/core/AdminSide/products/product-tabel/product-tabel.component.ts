import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { IproductShow } from 'src/app/models/i-product-variant';
import { ProductFormService } from 'src/app/services/product-form.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-product-tabel',
  templateUrl: './product-tabel.component.html',
  styleUrls: ['./product-tabel.component.css']
})
export class ProductTabelComponent implements OnInit {

  mainList : IproductShow [] = [];
  productList : IproductShow[] = [];
  p : number = 1;
  searchNmae : string = "";
  waiting : boolean = true;
  noitem : boolean = false;
  constructor( private prodServ:ProductFormService ){}
  ngOnInit(): void {
    this.getallProduct();
  }

  allProductSub : Subscription | undefined;

  getallProduct(){
    this.allProductSub = this.prodServ.getAllProduct().subscribe({
      next:(data) => {
        
        if (data.length ==0 ){
          this.noitem = true;
        }
        this.mainList = data;
        this.productList=data;
        this.waiting = false;
      } ,
      error:(e) => {
        console.log("ERROR: " + e);
        this.noitem = true;
      }
    })
  }

  deleteProduct (id : number) {
    Swal.fire({
      title: 'هل أنت متأكد من أنك تريد حذف المنتج؟!',
      confirmButtonColor: '#198754', // لون زر التأكيد
      confirmButtonText: 'تأكيد',
      cancelButtonText: 'إلغاء',
      showCancelButton: true,
      cancelButtonColor: '#dc3545' // لون زر الإلغاء
    }).then((result) => {if (result.isConfirmed) {
      this.prodServ.deleteProduct(id).subscribe({
        next: ()=> {this.getallProduct();},
        error: (e) => {
          console.log("ERROR When delete product" + e);
        }
      })
    }})

  }

  nameSearch : FormGroup = new FormGroup({
    name: new FormControl("")
  })

  sumbit(e:Event){
    this.searchNmae = this.nameSearch.get('name')?.value;
    this.applyFilter();
  }

  applyFilter(){
    this.productList = this.mainList.filter(item =>
      item.name.toLowerCase().includes(this.searchNmae.toLowerCase()) 
    );
  }
}
