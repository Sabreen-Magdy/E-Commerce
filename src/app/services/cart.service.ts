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
  baseURL :string ="http://www.srm.somee.com/api/Cart";
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
    console.log("Ya Allahhhhhhhhh",this.authservice.id);
    this.getCartBycstId(this.authservice.id).subscribe({
    next: (data) => {
      console.log(data);
      let filterdata = data.items.filter((item)=>item.state==0);
      this.numberOfitemInCart.next(filterdata.length);
      console.log(this.numberOfitemInCart.getValue());
    }
  });

 }

  deleteCartItemByCID (customerId : number, productVarient : number){
    return this.http.delete(`${this.baseURL}/DeleteItem?costomerId=${customerId}&productVarientId=${productVarient}`)
  }

}
