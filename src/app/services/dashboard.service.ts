import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  constructor(private http : HttpClient) { }
  BaseUrl : string ="http://localhost:5058/api/Saller/"

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

  getprofitByYear():Observable<number>{
    return this.http.get<number>(`${this.BaseUrl}GetProfitByYear?state=1`)
  }
  getprofitByweekDay():Observable<number>{
    return this.http.get<number>(`${this.BaseUrl}GetProfitByYear?state=1`)
  }
}
