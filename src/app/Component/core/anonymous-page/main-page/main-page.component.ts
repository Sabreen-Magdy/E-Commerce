import { ComponentUrl } from 'src/app/models/unit';
import { Component } from '@angular/core';
import { AuthService } from 'src/app/auth.service';
import { FavoriteService } from 'src/app/services/favorite.service';

AuthService
@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css'],
})
export class MainPageComponent {
  ComponentUrl = ComponentUrl;


}
