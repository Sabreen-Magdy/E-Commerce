import { Component } from '@angular/core';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent {

  toggle() {
    var blur = document.getElementById('blur');
    blur?.classList.toggle('active')
    var popup = document.getElementById('popup');
    popup?.classList.toggle('active')
  }
}
