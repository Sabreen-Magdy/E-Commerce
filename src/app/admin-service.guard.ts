import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class adminServiceGuard implements CanActivate {

  constructor(private _AuthService:AuthService,private _Router:Router) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    if(localStorage.getItem('loginToken') != null && this._AuthService.userRole=="Saller"){
      return true;
    }
    else{
      this._Router.navigate(['/home']);
      return false;
    }
  }
}
