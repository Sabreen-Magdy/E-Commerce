import { Component } from '@angular/core';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-anonymous-page',
  templateUrl: './anonymous-page.component.html',
  styleUrls: ['./anonymous-page.component.css']
})
export class AnonymousPageComponent {
  isCustomer: boolean = false;

  constructor(private _AuthService:AuthService){}
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
}
