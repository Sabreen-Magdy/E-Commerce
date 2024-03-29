import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IReview, ProductIReview } from '../models/ireview';

@Injectable({
  providedIn: 'root'
})
export class ProductReviewService {
  private baseURL: string = "http://localhost:5058/api/Review";

  constructor(private http: HttpClient) { }

 

  getProductReviewById(id: number): Observable<ProductIReview> {
    return this.http.get<ProductIReview>(`${this.baseURL}/product?productId=${id}`);
  }

  addProductReview(review: IReview): Observable<ProductIReview> {
    return this.http.post<ProductIReview>(`${this.baseURL}/http://localhost:5058/api/Review`, review);
  }


}
