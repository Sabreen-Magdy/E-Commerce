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

  
  getCartBycstId(id: number): Observable<CartDto> {
    return this.http.get<CartDto>(`${this.baseURL}/GetByCustomerId?customerId=${id}`);
  }

  addCartItem(Customerid: number,cartitem:AddCart)  {
    return this.http.post(`${this.baseURL}/AddItem?customerId=${Customerid}`, cartitem );
  }

  updateCartItem(customerid: number,productId:number,Cartitem: Uppdatecart) {
    return this.http.put(`${this.baseURL}/UpdateItem?costomerId=${customerid}&productId=${productId}`, Cartitem);
  }

  deleteCartitem(id: number) {
    return this.http.delete(`${this.baseURL}/DeleteItemById?id=${id}`);
  }

  deleteCartItemByCID (customerId : number, productVarient : number){
    return this.http.delete(`${this.baseURL}/DeleteItem?costomerId=${customerId}&productVarientId=${productVarient}`)
  }
}
