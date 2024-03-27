import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FavoriteService {
  baseURL :string ="http://localhost:5058/api//";
  constructor() { }
}
