import { Injectable } from '@angular/core';
import { Icart } from '../models/icart';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class CartService {
  baseURL :string ="http://localhost:5058/api/Cart";
  constructor( private http: HttpClient) { }
  getAllCart() : Observable<Icart[]>{

    return this.http.get<Icart[]>(`${this.baseURL}GetAll`)
  } 
  getCartById(id: number): Observable<Icart> {
    return this.http.get<Icart>(`${this.baseURL}/GetById/${id}`);
  }

  addCart(cart: Icart): Observable<Icart> {
    return this.http.post<Icart>(`${this.baseURL}/Add`, cart);
  }

  updateCart(cart: Icart): Observable<Icart> {
    return this.http.put<Icart>(`${this.baseURL}/Update`, cart);
  }

  deleteCart(id: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/Delete/${id}`);
  }
}
