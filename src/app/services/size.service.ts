import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Isize } from '../models/isize';

@Injectable({
  providedIn: 'root'
})
export class SizeService {

  baseURL : string = 'http://srmgroub.somee.com/api/General'

  // baseURL : string = 'http://localhost:5058/api/General'
  constructor(private http:HttpClient) { }

  getAllSize() : Observable<Isize[]>{
    return this.http.get<Isize[]>(`${this.baseURL}/GetAllSize`)
   }

  addsize(name: string) {
    return this.http.post(`${this.baseURL}/AddSize?name=${encodeURIComponent(name)}`, {});
  }

  editSize(size : Isize){
    return this.http.put(`${this.baseURL}/UpdateSize`,size)
  }
  
  deletesize(id: number){
    return this.http.delete(`${this.baseURL}/DeleteSize?id=${id}`)
  }  
}
