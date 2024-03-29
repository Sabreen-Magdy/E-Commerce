import { Component } from '@angular/core';
import { AuthService } from 'src/app/auth.service';
import { FavoriteService } from 'src/app/services/favorite.service';

@Component({
  selector: 'app-home-page-layout',
  templateUrl: './home-page-layout.component.html',
  styleUrls: ['./home-page-layout.component.css']
})
export class HomePageLayoutComponent {
  constructor(private favService:FavoriteService){}
  ngOnInit(){
    this.favService.getNumberOfitemInFavCart();
  }

}
