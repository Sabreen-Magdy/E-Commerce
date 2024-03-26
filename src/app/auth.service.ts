import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private token: boolean =false;

  constructor(private _HttpClient:HttpClient) { }
  signUp(userData:object):Observable<any>
  {
    return this._HttpClient.post('http://localhost:5058/api/Customer/AddCustomers/',userData);
  }
  signIn(email:string,password:string) : Observable<any>
  {
     return this._HttpClient.get<any>(`http://localhost:5058/api/Authentication?email=${email}&password=${password}`)
     
  }

  IsLogin(): boolean {
    return this.token;
  }
}
