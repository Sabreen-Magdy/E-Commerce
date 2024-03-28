import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProductAddForm, IproductShow } from '../models/i-product-variant';
import { TagContentType } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class ProductFormService {

  baseURL : string ="http://localhost:5058/api/Saller/";
  baseURL2 : string = "http://localhost:5058/api/Product/";
  constructor( private http:HttpClient) { }

  addProduct (product:IProductAddForm){
    this.http.head
     return  this.http.post(`${this.baseURL}Add`,product)
  }

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
