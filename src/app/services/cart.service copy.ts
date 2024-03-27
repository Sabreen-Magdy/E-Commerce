import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {
 // baseURL :string ="http://localhost:5058/api/Cart/";
  constructor( private http:HttpClient) { }

}