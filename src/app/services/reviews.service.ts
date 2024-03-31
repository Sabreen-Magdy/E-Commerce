import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IReview, ProductIReview, Review } from '../models/ireview';

@Injectable({
  providedIn: 'root'
})
export class ProductReviewService {
  private baseURL: string = "http://srmgroub.somee.com/api/Customer/";

  constructor(private http: HttpClient) { }



  getProductReviewById(id: number): Observable<ProductIReview> {
    return this.http.get<ProductIReview>(`${this.baseURL}/product?productId=${id}`);
  }

  addProductReview(customerId: number, productId: number, comment: string, rate: number) {
    console.log(customerId,productId,rate,comment)
    return this.http.post(`${this.baseURL}AddReview?customerId=${customerId}&productId=${productId}&comment=${comment}&rate=${rate}`,{});
  }



}
