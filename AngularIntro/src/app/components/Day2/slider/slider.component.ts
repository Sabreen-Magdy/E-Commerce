import { Component } from '@angular/core';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css'],
})
export class SliderComponent {
  imagesUrls: string[] = ['assets/images/home.jpg', 'assets/images/home2.jpg'];

  currentImage: string = this.imagesUrls[0];

  counter:number = 0;
  next(){
    this.counter++;
    if(this.counter == this.imagesUrls.length) this.counter=0;
    this.currentImage = this.imagesUrls[this.counter];
  }

  play(){
    setInterval(()=>{

    });
  }
}
