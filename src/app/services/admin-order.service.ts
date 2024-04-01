import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AdminOrder } from '../models/admin-order';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminOrderService {

  constructor(private http : HttpClient) { }
  baseUrl :string = "http://srmgroub.somee.com/api/Saller/"
  getAll():Observable<AdminOrder[]>{
    return this.http.get<AdminOrder[]>(this.baseUrl+"GetAllOrders")
  }

  UpdateStatus(orderid:number , status:number, comment:string){
    const url = `${this.baseUrl}UpdateOrderStatus?id=${orderid}&status=${status}&comment=${comment}`;
    return this.http.put(url,null)
  }
}
