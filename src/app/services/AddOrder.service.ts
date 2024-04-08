import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddPaymentOrder, IorderAdd } from '../models/order';

@Injectable({
  providedIn: 'root'
})


export class addorderService {
  baseURL :string ="http://www.srm.somee.com/api/Order/";

  constructor( private http:HttpClient ){}

  addorder(order:AddPaymentOrder) {
    return this.http.post(`${this.baseURL}AddOrder`,order)
  }
  
}

