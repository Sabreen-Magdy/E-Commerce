import { Payment } from './../models/payment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import * as braintree from 'braintree-web';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private http :HttpClient) { }
  baseUrl : string ='http://www.srm.somee.com/api/Payment/'
  getPaymentToken():Observable<string>{
    return this.http.get(`${this.baseUrl}PaymentToken`, { responseType: 'text' })
  }

  Pay(payment:Payment){
    return this.http.post(`${this.baseUrl}Pay`, payment)
  }
}
