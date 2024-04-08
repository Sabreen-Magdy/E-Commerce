import { DeleteComponent } from './../Component/core/AdminSide/delete/delete.component';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {  ICstDto } from '../models/deletecomment';

@Injectable({
  providedIn: 'root'
})
export class DeleteService {

  baseURL : string = 'http://www.srm.somee.com/api/Customer';
  baseURL2 : string = 'http://www.srm.somee.com/api/Saller';

  constructor(private http: HttpClient) {}
  getCSTall(): Observable<ICstDto[]> {
    return this.http.get<ICstDto[]>(`${this.baseURL}/GetAllCustomers`);
  }
  deletebtitem(id: number) {
    return this.http.delete(`${this.baseURL}/DeleteCustomers?id=${id}`);
  }
}

