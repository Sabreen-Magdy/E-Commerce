import { Component } from '@angular/core';
import { FavoriteService } from './services/favorite.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'project';
  constructor(private favService:FavoriteService){}
  ngOnInit(){
    this.favService.getNumberOfitemInFavCart();
  }
}
