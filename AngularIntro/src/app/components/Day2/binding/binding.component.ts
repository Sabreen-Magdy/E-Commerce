import { Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-binding',
  templateUrl: './binding.component.html',
  styleUrls: ['./binding.component.css'],
})
export class BindingComponent {
  printMesage() {
    console.log('Event Binding Works');
  }

  printVal(e: Event) {
    var element = e.target as HTMLInputElement;
    console.log(element.value);
  }

  // printAge(ageRef: HTMLInputElement) {
  printAge(value: string) {
    console.log(value);
  }


  @ViewChild('ageIn')  ageEl: ElementRef | undefined;
  @ViewChild('nameIn') nameEl: any;
  printValues(){
    console.log(this.ageEl?.nativeElement.value);
    console.log(this.nameEl.nativeElement.value);
  }
}
