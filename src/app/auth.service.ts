import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import { customerOrder } from './models/customerOrder';
import { IproductShow } from './models/i-product-variant';
import { IRegisteration } from './models/auth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private _HttpClient:HttpClient,private _Router:Router) {
    if(localStorage.getItem('loginToken') != null){
      this.saveUserData();
    }
  }
  private token: boolean =false;
  user:any;
  userData:any=new BehaviorSubject(null);
  sharedVariable: any;
  idMatch:any;
  id:any;
  userRole:any;
  allProducts : IproductShow [] = [];
  userDataSubscription: Subscription|undefined;
  saveUserData(){
      let encodedToken=JSON.stringify(localStorage.getItem('loginToken')) ;
      let decodedToken=jwtDecode(encodedToken);
      this.user=decodedToken;
      this.userData.next(this.user.Role);
      this.userDataSubscription = this.userData.subscribe((userData: string) => {
        // Match the Id value using a regex pattern
        this.idMatch = userData.match(/Id\s*=\s*(\d+)/);
        this.id = this.idMatch ? this.idMatch[1] : null;
        this.userRole=userData.split('=')[2].trim().slice(0, -1);
      });

  }
  signUp(userData:object):Observable<any>
  {
    return this._HttpClient.post('http://srmgroub.somee.com/api/Customer/AddCustomers/',userData);
  }
  signIn(Email:string,Password:string) : Observable<any>
  {
    console.log("hi from service");
    let userDataAyth={
      email: Email,
      password: Password
    }
     this._HttpClient.post<any>(`http://srmgroub.somee.com/api/Authentication/Login`,userDataAyth).subscribe({
      next:(response)=>{
        console.log(response)
        if(response.token) {
             localStorage.setItem('loginToken',response.token);
             this.saveUserData();
        }
        console.log(this.userRole)
        // if(this.userRole=="Customer"){
        //   console.log("ggggggggggggggggggggggggggggggggggggggggggggggggggg")
        // }
      }
    });

     return  this._HttpClient.post<any>(`http://srmgroub.somee.com/api/Authentication/Login`,userDataAyth);
  }
  signOut(){
    localStorage.removeItem('loginToken');
    this.userData.next(null);
    this._Router.navigate(['/main']);
  }
  getDataOfUser():Observable<any>{
   return this._HttpClient.get<any>(`http://srmgroub.somee.com/api/Customer/GetCustomerById?id=${this.id}`);
  }
  updateUser(data:object):Observable<any>{
    return this._HttpClient.put<any>(`http://srmgroub.somee.com/api/Customer/UpdateCustomers?id=${this.id}`,data);
   }

 getOrderOfUser():Observable<customerOrder[]>{
  return this._HttpClient.get<customerOrder[]>(`http://srmgroub.somee.com/api/Customer/GetOrders?id=${this.id}`);
 }

 getallProduct() {
  return this._HttpClient.get<IproductShow[]>("http://srmgroub.somee.com/api/Product/GetAll").subscribe({
    next: (data) => {
      console.log("hiiii");
      console.log(data[0]);
      this.allProducts = data;
    }
  });
 }

 
 Registeration(data : IRegisteration){
  
  return this._HttpClient.post(`http://localhost:5058/api/Authentication/Registeration`,data)
 }

confirmEmail(email : string): Observable<any> {
  
  const encodedEmail = encodeURIComponent(email); 
  return this._HttpClient.get<any>(
    `http://localhost:5058/api/Authentication/ConfirmEmail?email=${encodedEmail}`, 
    { headers: { 'RedirectUrl': 'http://localhost:4200/signup?' } }
  );
}


}
