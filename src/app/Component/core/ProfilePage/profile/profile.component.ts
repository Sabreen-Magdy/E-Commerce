import { Component,OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  name:string=""
  email:string=""
  phone:string=""
  password:string=""
  constructor(private _AuthService:AuthService){}
  ngOnInit(): void {
     this._AuthService.getDataOfUser().subscribe(
      { next:(response)=>{
          this.name= response.name;
          this.email=response.email;
          this.phone= response.phone;
          this.password=response.password;
    }
  });
  }
}
