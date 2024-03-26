import { Component } from '@angular/core';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  id:number=0
  name:string=""
  email:string=""
  phone:string=""
  password:string=""
  constructor(private _AuthService:AuthService){}

}
