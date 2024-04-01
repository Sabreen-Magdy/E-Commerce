import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IorderAdd } from '../models/order';

@Injectable({
  providedIn: 'root'
})


export class addorderService {
  baseURL :string ="http://srmgroub.somee.com/api/Order/";

  constructor( private http:HttpClient ){}

  addorder(order:IorderAdd) {
    return this.http.post(`${this.baseURL}AddOrder`,order)
  }
  
}

