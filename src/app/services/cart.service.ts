import { CartItemDto, Uppdatecart } from './../models/icart';
import { Injectable } from '@angular/core';
import { AddCart, CartDto } from '../models/icart';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../auth.service';


@Injectable({
  providedIn: 'root'
})
export class CartService {
  baseURL :string ="http://localhost:5058/api/Cart";
  numberOfitemInCart:any=new BehaviorSubject(null);

  constructor( private http: HttpClient,private authservice:AuthService) { }

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
  getNumberOfitemInCart(){
    this.getCartBycstId(this.authservice.id).subscribe({
    next: (data) => {
      console.log(data.totalQuantity);
      this.numberOfitemInCart.next(data.totalQuantity);
      console.log(this.numberOfitemInCart.getValue());
    }
  });

 }
}
