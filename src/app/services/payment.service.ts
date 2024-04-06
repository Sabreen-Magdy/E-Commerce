import { Payment } from './../models/payment';
import { HttpClient, HttpContext, HttpHeaders } from '@angular/common/http';
import { Injectable, Version } from '@angular/core';
import { Observable } from 'rxjs';
// import { HttpVersion } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private http :HttpClient) { }
  baseUrl : string ='http://www.srm.somee.com/api/Payment/'//http://localhost:5058/api/Payment/
  getPaymentToken():Observable<string>{
    return this.http.get(`${this.baseUrl}PaymentToken`, { responseType: 'text' })
  }
//http://www.srm.somee.com/api/Payment/
  Pay(payment:Payment){
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    // Specify HTTP/1.1 version
    const httpOptions = {
      headers: headers,
      
      httpVersion: '1.2'
    };
    return this.http.post(`${this.baseUrl}Pay`, payment,httpOptions)
  }
}
