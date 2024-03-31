import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProductVariant } from '../models/i-product-variant';
import { IproductDTo } from '../models/iproduct-dto';
import { IproductVarDet } from '../models/iproduct-var-det';
import { IproductReviws } from '../models/iproduct-reviws';
import { ActivatedRoute, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ProductDetailsService {

  baseUrl : string ="http://srmgroub.somee.com/api/Product"
  //http://localhost:5058/api/Product/GetDetailsById
  constructor(private http :HttpClient , private router:ActivatedRoute) { }
 
  getAll(id:number):Observable<IproductVarDet[]>{
    
    return this.http.get<IproductVarDet[]>(`${this.baseUrl}/GetVarientsById?id=${id}`)
  }
  getProd(id:number):Observable<IproductDTo>{
    return this.http.get<IproductDTo>(`${this.baseUrl}/GetDetailsById?id=${id}`)
  }
   getProdReviews(id:number):Observable<IproductReviws[]>{
    return this.http.get<IproductReviws[]>(`${this.baseUrl}/GetProductReviews?id=${id}`)
  }
}
