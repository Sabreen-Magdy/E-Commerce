import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { favitem, IaddFavorite, Ifav } from '../models/Ifav';

@Injectable({
  providedIn: 'root'
})


export class FavoriteService {
  baseURL :string ="http://localhost:5058/api/Favourite/";
 
  constructor(private _HttpClient:HttpClient) {}

  
  getallFavbycustomr(id : number): Observable<favitem[]>{
    return this._HttpClient.get<favitem[]>(`${this.baseURL}GetByCustomerId?customerId=${id}`)
  }

  additemTofav(data :IaddFavorite){
    return this._HttpClient.post(`${this.baseURL}AddFavorite`,data)
  }

  getFavProductCustomer (customerId : number, productId : number) : Observable<favitem>
  {
    return this._HttpClient.get<favitem>(`${this.baseURL}GetByProductCustomer?customerId=${customerId}&productId=${productId}`)
  }

  deletefavitem(customerId : number, productId : number )
  {
    return this._HttpClient.delete(`${this.baseURL}DeleteFavorite?customerId=${customerId}&productId=${productId}`)
  }



}
