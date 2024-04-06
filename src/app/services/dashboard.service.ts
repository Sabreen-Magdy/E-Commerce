import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Dashboard } from '../models/dashboard';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  constructor(private http : HttpClient) { }
  BaseUrl : string ="http://www.srm.somee.com/api/Saller/"

  getProfit():Observable<number>{
    return this.http.get<number>(`${this.BaseUrl}GetProfit?state=1`)
  }
  getCustomerNum():Observable<number>{
    return this.http.get<number>(`${this.BaseUrl}GetNumberCustomers`)
  }

  getProductNum():Observable<number>{
    return this.http.get<number>(`${this.BaseUrl}GetNumberProducts`)
  }

  getOrderNum():Observable<number>{
    return this.http.get<number>(`${this.BaseUrl}GetNumberOrders?state=1`)
  }

  getprofitByYear():Observable<Dashboard[]>{
    return this.http.get<Dashboard[]>(`${this.BaseUrl}GetProfitByYear?state=1`)
  }
  getprofitByweek():Observable<Dashboard[]>{
    return this.http.get<Dashboard[]>(`${this.BaseUrl}GetProfitByWeek?state=1`)
  }
}
