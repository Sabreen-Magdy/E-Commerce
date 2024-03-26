import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  imageSrc: string = 'assets/Images/home2.jpg';

  username: string = 'Ali Mohamed';

  mycolor: string = 'red';

  ApplyRed: boolean = false;
}
