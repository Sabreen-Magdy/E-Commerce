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
  otp : string = "";
  tokenForget : string = "";
  email:string="";
  saveUserData(){
      let encodedToken=JSON.stringify(localStorage.getItem('loginToken')) ;
      let decodedToken:any=jwtDecode(encodedToken);
      console.log(decodedToken);
      // console.log("exp========",decodedToken.exp);
      this.user=decodedToken;
      this.userData.next(this.user);
      this.userDataSubscription = this.userData.subscribe((userData: any) => {
         let testId=localStorage.getItem('idUser')
         this.id=testId;
         let testRole=localStorage.getItem('roleUser')
         this.userRole=testRole;
         console.log("idUser",this.id)
         console.log("userRole",this.userRole)

        // this.idMatch = userData.match(/Id\s*=\s*(\d+)/);
        // this.id = this.idMatch ? this.idMatch[1] : null;
        // userData.split('=')[2].trim().slice(0, -1);
      });

  }
  signUp(userData:object):Observable<any>
  {
    return this._HttpClient.post('http://www.srm.somee.com/api/Customer/AddCustomers/',userData);
  }
  signIn(Email:string,Password:string) : Observable<any>
  {
    let userDataAyth={
      email: Email,
      password: Password
    }
    // http://srmgroub.somee.com/api/Authentication/Login
    console.log(userDataAyth);
     this._HttpClient.post<any>(`http://www.srm.somee.com/api/Authentication/Login`,userDataAyth).subscribe({
      next:(response)=>{
        console.log(response)
        if(response.token) {
             localStorage.setItem('loginToken',response.token);
             localStorage.setItem('idUser',response.id);
             localStorage.setItem('roleUser',response.role[0]);
             this.id=response.id;
             this.userRole=response.role[0];
             this.saveUserData();
        }

        console.log(this.userRole)
      }
    });

     return  this._HttpClient.post<any>(`http://www.srm.somee.com/api/Authentication/Login`,userDataAyth);
  }
  signOut(){
    localStorage.removeItem('loginToken');
    this.userData.next(null);
    this._Router.navigate(['/home']);
  }
  getDataOfUser():Observable<any>{
   return this._HttpClient.get<any>(`http://www.srm.somee.com/api/Customer/GetCustomerById?id=${this.id}`);
  }
  updateUser(data:object):Observable<any>{
    return this._HttpClient.put<any>(`http://www.srm.somee.com/api/Customer/UpdateCustomers?id=${this.id}`,data);
   }

 getOrderOfUser():Observable<customerOrder[]>{
  return this._HttpClient.get<customerOrder[]>(`http://www.srm.somee.com/api/Customer/GetOrders?id=${this.id}`);
 }

 getallProduct() {
  return this._HttpClient.get<IproductShow[]>("http://www.srm.somee.com/api/Product/GetAll").subscribe({
    next: (data) => {
      console.log("hiiii");
      console.log(data[0]);
      this.allProducts = data;
    }
  });
 }


 Registeration(data : IRegisteration){
  console.log(data)
  return this._HttpClient.post(`http://www.srm.somee.com/api/Authentication/Registeration`,data)
 }

confirmEmail(email : string): Observable<any> {

  const encodedEmail = encodeURIComponent(email);
  return this._HttpClient.get<any>(
    `http://www.srm.somee.com/api/Authentication/ConfirmEmail?email=${encodedEmail}`,
    { headers: { 'RedirectUrl': 'http://localhost:4200/signup?' } }
  );
}

forgetPassWord(email : string)  {
  return this._HttpClient.post<any>(`http://www.srm.somee.com/api/Authentication/ForgetPassword?email=${email}`,{})
}
resetPassWord(userData:object):Observable<any>
  {
    return this._HttpClient.post('http://www.srm.somee.com/api/Authentication/ResetPassword/',userData);
  }
  updatePassWord(userData:object):Observable<any>
  {
    return this._HttpClient.post('http://localhost:5058/api/Authentication/UpdatePassword/',userData,
    { headers: { 'token': `${this.user}` } }
    );
  }
}


