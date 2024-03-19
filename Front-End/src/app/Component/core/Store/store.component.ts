import { Component } from '@angular/core';
import { ComponentUrl } from 'src/app/models/unit';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css'],
})
export class StoreComponent {
  ComponentUrl = ComponentUrl;
  toggle() {
    var blur = document.getElementById('blur');
    blur?.classList.toggle('active');
    var popup = document.getElementById('popup');
    popup?.classList.toggle('active');
  }
}
