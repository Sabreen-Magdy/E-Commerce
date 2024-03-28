
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IProductAddForm, IproductShow } from '../models/i-product-variant';

@Injectable({
  providedIn: 'root'
})
export class ProductFormService {

  baseURL : string ="http://localhost:5058/api/Saller/";
  baseURL2 : string = "http://localhost:5058/api/Product/";

  productsCache: IproductShow[] = [];

  constructor( private http:HttpClient) { }

  addProduct (product:IProductAddForm){
    this.http.head
     return  this.http.post(`${this.baseURL}Add`,product)
  }

  fetchAndCacheProducts(): Observable<IproductShow[]> {
    console.log("fetch");
    if (this.productsCache.length == 0 ) {
      console.log("fetch form service");
      return this.http.get<IproductShow[]>(`${this.baseURL2}GetAll`).pipe(
        tap(products => this.productsCache = products) // Cache the products
      );
    }  
    else {

      console.log("osjsk");
      // If products are cached, return the cached products as an Observable
      return of(this.productsCache);
    }
  }


  get length (){
    return 0 
  }
  getAllProduct2(): Observable<IproductShow[]> {
    console.log("getAllproduct2");
    return this.fetchAndCacheProducts();
  }

  // getState(){
  //   if (this.productsCache.length == 0) {

  //   }
  // }

  getAllProduct () : Observable <IproductShow[]> {
    return this.http.get<IproductShow[]>(`${this.baseURL2}GetAll`)
  }

  gatProductbyCategoryName(catName : string) : Observable <IproductShow[]>
  {
    return this.http.get<IproductShow[]>(`${this.baseURL2}GetByGetegory?gategory=${catName}`)
  }

  getProductByName (prodName : string) : Observable<IproductShow[]> {
    return this.http.get<IproductShow[]>(`${this.baseURL2}GetByName?name=${prodName}`)
  }

  deleteProduct (id : number) {
    return this.http.delete(`${this.baseURL}DeleteProduct?id=${id}`)
  }

}
