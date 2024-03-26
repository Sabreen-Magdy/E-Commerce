import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICategory } from '../models/i-category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  baseURL :string ="http://localhost:5058/api/Category/";
  constructor( private http:HttpClient) { }

  getAllCategs() : Observable<ICategory[]>{

    return this.http.get<ICategory[]>(`${this.baseURL}GetAll`)
  }

  getById (id : number) : Observable <ICategory> {
    return this.http.get<ICategory>(`${this.baseURL}GetById?id=${id}`)
  }

  addCategory(categ :object ){
    
    return this.http.post(`${this.baseURL}Add`,categ)
  }

  deleteCategory (id : number) {
    return this.http.delete(`${this.baseURL}Delete?id=${id}`)
  }
}
