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

  // http://localhost:5058/api/Product/GetProductReviews?id=31
  // /AddReview?customerId=1&productId=32&comment=%D8%AC%D8%A7%D9%85%D8%AF&rate=5

  getProductReviewById(id: number): Observable<ProductIReview> {
    return this.http.get<ProductIReview>(`http://srmgroub.somee.com/api/Product/GetProductReviews?id=${id}`);
  }

  addProductReview(customerId: number, productId: number, comment: string, rate: number) {
    console.log(customerId,productId,rate,comment)
    return this.http.post(`${this.baseURL}AddReview?customerId=${customerId}&productId=${productId}&comment=${comment}&rate=${rate}`,{});
  }
isCustomerCanAddRev(customerId:number,productId:number):Observable<any>{
  return this.http.get<any>(`${this.baseURL}CanAddReview?id=${customerId}&productId=${productId}`);
}


}
