import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  baseURL :string ="http://localhost:5058/api/Cart/";
  constructor() { }
}
