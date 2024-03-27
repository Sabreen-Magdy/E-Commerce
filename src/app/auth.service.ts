import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';

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
        console.log(this.id);
      });
  }
  signUp(userData:object):Observable<any>
  {
    return this._HttpClient.post('http://localhost:5058/api/Customer/AddCustomers/',userData);
  }
  signIn(email:string,password:string) : Observable<any>
  {
     this._HttpClient.get<any>(`http://localhost:5058/api/Authentication?email=${email}&password=${password}`).subscribe({
      next:(response)=>{
        if(response.token) {
             localStorage.setItem('loginToken',response.token);
             this.saveUserData();
        }
      }
    });

     return this._HttpClient.get<any>(`http://localhost:5058/api/Authentication?email=${email}&password=${password}`)

  }
  signOut(){
    localStorage.removeItem('loginToken');
    this.userData.next(null);
    this._Router.navigate(['/main']);
  }
  getDataOfUser():Observable<any>{
   return this._HttpClient.get<any>(`http://localhost:5058/api/Customer/GetCustomerById?id=${this.id}`);
  }
  updateUser(data:object):Observable<any>{
    return this._HttpClient.put<any>(`http://localhost:5058/api/Customer/UpdateCustomers?id=${this.id}`,data);
   }



}
