import { Component } from '@angular/core';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-navbar2',
  templateUrl: './navbar2.component.html',
  styleUrls: ['./navbar2.component.css']
})
export class Navbar2Component {
  showMenu: boolean = false;
  isCustomer: boolean = false;
  constructor(private _AuthService:AuthService){
  }
  ngOnInit():void{
    this._AuthService.userData.subscribe({
      next:()=>{
        if(this._AuthService.userData.getValue()!=null){
          this.isCustomer=true;
        }else{
          this.isCustomer=false;
        }
      }
    });
  }

  toggleMenu(): void {
    this.showMenu = !this.showMenu;
  }

  logOut(){
    this._AuthService.signOut()
  }

}
