import { Component} from '@angular/core';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-profiledetaile',
  templateUrl: './profiledetaile.component.html',
  styleUrls: ['./profiledetaile.component.css']
})
export class ProfiledetaileComponent {
  name:string=""
  email:string=""
  phone:string=""
  password:string=""
  constructor(private _AuthService:AuthService){}
  ngOnInit(): void {
    this._AuthService.userData.subscribe({
      next:()=>{
        if(this._AuthService.userData.getValue()!=null){
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
    });
  }

}
