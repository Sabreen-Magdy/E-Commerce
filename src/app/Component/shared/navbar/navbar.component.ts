import { Component, HostListener } from '@angular/core';
import { ComponentUrl } from 'src/app/models/unit';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  ComponentUrl = ComponentUrl;
  // @HostListener('window:scroll', ['$event'])
  // onScroll(event: Event) {
  //   var nav = document.getElementById('navbar');
  //   let pos =
  //     (document.documentElement.scrollTop || document.body.scrollTop) +
  //     document.documentElement.offsetHeight;
  //   console.log(pos, window.innerHeight);
  //   if (pos >= 3304) nav!.style.backgroundColor = 'white';
  //   else nav!.style.backgroundColor = 'transparent';
  // }
}
