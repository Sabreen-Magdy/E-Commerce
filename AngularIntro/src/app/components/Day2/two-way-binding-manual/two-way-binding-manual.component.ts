import { Component } from '@angular/core';

@Component({
  selector: 'app-two-way-binding-manual',
  templateUrl: './two-way-binding-manual.component.html',
  styleUrls: ['./two-way-binding-manual.component.css'],
})
export class TwoWayBindingManualComponent {
  InputValue: string = '';

  changeValue(value: string) {
    this.InputValue = value;
  }

  counter: number = 0;
  Count() {
    this.counter ++;
  }
}
