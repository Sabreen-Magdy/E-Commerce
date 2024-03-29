import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private _AuthService:AuthService,private _Router:Router) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    if(this._AuthService.userData.getValue() != null&&this._AuthService.userRole=="Customer "){
      return true;
    }else if(this._AuthService.userRole=="Saller "){
      this._Router.navigate(['/admin/dashboard']);
      return false;
    }
    else{
      this._Router.navigate(['/main']);
      return false;
    }
  }
}
