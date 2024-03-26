import { Component } from '@angular/core';

@Component({
  selector: 'app-form-with-validation',
  templateUrl: './form-with-validation.component.html',
  styleUrls: ['./form-with-validation.component.css'],
})
export class FormWithValidationComponent {
  name: string = '';
  age: number = 0;

  SendValues(e: Event) {
    e.preventDefault();
    if (this.NameValidation && this.AgeValidation) {
      console.log(this.name, this.age);
    }
  }

  get NameValidation() {
    return this.name.length >= 5;
  }
  get NameTouched() {
    return this.name != '';
  }

  get AgeValidation() {
    return this.age >= 18 && this.age <= 25;
  }
  get AgeTouched() {
    return this.age > 0;
  }
}
