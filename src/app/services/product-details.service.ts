import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProductVariant } from '../models/i-product-variant';
import { IproductDTo } from '../models/iproduct-dto';
import { IproductVarDet } from '../models/iproduct-var-det';

@Injectable({
  providedIn: 'root'
})
export class ProductDetailsService {

  baseUrl : string ="http://localhost:5058/api/Product"
  //http://localhost:5058/api/Product/GetDetailsById
  constructor(private http :HttpClient) { }
  getAll():Observable<IproductVarDet[]>{
    return this.http.get<IproductVarDet[]>(`${this.baseUrl}/GetVarientsById?id=${1}`)
  }
  getProd():Observable<IproductDTo>{
    return this.http.get<IproductDTo>(`${this.baseUrl}/GetDetailsById?id=${1}`)
  }
}
