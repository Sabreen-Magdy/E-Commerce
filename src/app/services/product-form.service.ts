import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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

  // addProduct (product:IProductAddForm){
  //   this.http.head
  //    return  this.http.post(`${this.baseURL}AddProduct`,product)
  // }
  addProduct(formData: FormData): Observable<any> {
    // Define headers if needed (for example, if you have custom headers)
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'multipart/form-data');

    return this.http.post<any>(`${this.baseURL}AddProduct`, formData, { headers: headers })
      // .pipe(
      //   catchError(this.handleError)
      // );
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
