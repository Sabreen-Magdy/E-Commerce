import { Component } from '@angular/core';
import { AuthService } from 'src/app/auth.service';
import { FavoriteService } from 'src/app/services/favorite.service';

@Component({
  selector: 'app-favorite',
  templateUrl: './favorite.component.html',
  styleUrls: ['./favorite.component.css']
})
export class FavoriteComponent {
  processedData: any[] = [];
  customerId:any;
 constructor(private _FavService:FavoriteService,private _AuthService:AuthService ){}
 ngOnInit(): void {
  this._AuthService.userData.subscribe({
    next:()=>{
      if(this._AuthService.userData.getValue()!=null){
        this.customerId=this._AuthService.id;
        this._FavService.getFavoriteByCustomerId(this.customerId).subscribe(
          { next:(response:any[])=>{
            console.log(response)
            this.processedData = response.map(order => {
              return {
                Image: order.image,
                Name: order.name,
                Price: order.price,
                Description: order.description
              };
            });
        }
      });
      }
    }
  });
 }
}
