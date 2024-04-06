import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { favitem, IaddFavorite, Ifav } from '../models/Ifav';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})


export class FavoriteService {
  baseURL :string ="http://www.srm.somee.com/api/Favourite/";
  // numberOfitemInFavCart:number=0;
  numberOfitemInFavCart:any=new BehaviorSubject(null);
  constructor(private _HttpClient:HttpClient,private authservice:AuthService) {}


  getallFavbycustomr(id : number): Observable<favitem[]>{
    return this._HttpClient.get<favitem[]>(`${this.baseURL}GetByCustomerId?customerId=${id}`);
  }
 getNumberOfitemInFavCart(){
    this.getallFavbycustomr(this.authservice.id).subscribe({
    next: (data) => {
      console.log(data.length);
      this.numberOfitemInFavCart.next(data.length);
      console.log(this.numberOfitemInFavCart.getValue());
    }
  });

 }
  additemTofav(data :IaddFavorite){
    return this._HttpClient.post(`${this.baseURL}AddFavorite`,data);
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
