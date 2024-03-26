import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private token: boolean =false;
  private id: number =0;

  constructor(private _HttpClient:HttpClient) { }
  signUp(userData:object):Observable<any>
  {
    return this._HttpClient.post('http://localhost:5058/api/Customer/AddCustomers/',userData);
  }
  signIn(email:string,password:string)
  {
     this._HttpClient.get<any>(`http://localhost:5058/api/Authentication?email=${email}&password=${password}`).subscribe({
      next:(response)=>{
        console.log(response)
        if(response.message==="success") {
             this.token=true;
             this.id=response.id;
        }
      }
    });
  }
  getDataOfUser():Observable<any>{
   return this._HttpClient.get<any>(`http://localhost:5058/api/Customer/GetCustomerById?id=${this.id}`);
  }
  IsLogin(): boolean {
    return this.token;
  }
}
