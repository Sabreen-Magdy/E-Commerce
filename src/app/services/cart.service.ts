import { CartItemDto, Uppdatecart } from './../models/icart';
import { Injectable } from '@angular/core';
import { AddCart, CartDto } from '../models/icart';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class CartService {
  baseURL :string ="http://localhost:5058/api/Cart";
  constructor( private http: HttpClient) { }

  // getCartItem(): Observable<CartDto[]> {
  //   return this.http.get<CartDto[]>(`${this.baseURL}/GetAll`);
  // }

  getCartBycstId(id: number): Observable<CartDto[]> {
    return this.http.get<CartDto[]>(`${this.baseURL}/GetByCustomerId?customerId${id}`);
  }

  addCartItem(id: number,cartitem:AddCart)  {
    return this.http.post<CartDto>(`${this.baseURL} /AddItem?customerId=${id}`, cartitem );
  }

  updateCartItem(id: number,productId:number,Cartitem: Uppdatecart) {
    return this.http.put<CartDto>(`${this.baseURL}/UpdateItem?costomerId=${id}&productId=${productId}`, Cartitem);
  }

  deleteCartitem(id: number) {
    return this.http.delete(`${this.baseURL}/DeleteItemById?id=${id}`);
  }
}
