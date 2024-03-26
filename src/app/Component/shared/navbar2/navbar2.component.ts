import { Component } from '@angular/core';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-navbar2',
  templateUrl: './navbar2.component.html',
  styleUrls: ['./navbar2.component.css']
})
export class Navbar2Component {
  showMenu: boolean = false;
  constructor(private _AuthService:AuthService){}
  toggleMenu(): void {
    this.showMenu = !this.showMenu;
  }
  IsLogin(){
    return this._AuthService.IsLogin();
  }
}
