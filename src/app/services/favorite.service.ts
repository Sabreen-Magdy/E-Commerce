import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Ifav } from '../models/Ifav';

@Injectable({
  providedIn: 'root'
})
export class FavoriteService {
  baseURL :string ="http://localhost:5058/api/Favourite/";
  secondBaseUrl:string="http://localhost:5058/api/Customer/";
  constructor(private _HttpClient:HttpClient,private _Router:Router) {
    if(localStorage.getItem('loginToken') != null){
      // this.saveUserData();
    }
  }

addToFavorite(favItem:Ifav):Observable<any>
{
  return this._HttpClient.post(`${this.baseURL}AddFavorite/`,favItem);
}
getFavoriteByCustomerId(customerId:number):Observable<any>
{
  return this._HttpClient.get(`http://localhost:5058/api/Customer/GetFavourites?id=${customerId}`);
}

}
