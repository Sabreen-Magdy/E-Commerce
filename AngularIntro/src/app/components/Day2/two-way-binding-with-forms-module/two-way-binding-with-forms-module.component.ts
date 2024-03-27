import { Component } from '@angular/core';

@Component({
  selector: 'app-two-way-binding-with-forms-module',
  templateUrl: './two-way-binding-with-forms-module.component.html',
  styleUrls: ['./two-way-binding-with-forms-module.component.css'],
})
export class TwoWayBindingWithFormsModuleComponent {
  name: string = '';
  age: number = 0;

  course: string = '';
  obj={
    fname:"ali",
    age:20
  }

  changeVal(value: string) {
    this.name = value;
  }
}
