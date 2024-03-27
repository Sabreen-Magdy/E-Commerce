import { Component } from '@angular/core';

@Component({
  selector: 'app-directives',
  templateUrl: './directives.component.html',
  styleUrls: ['./directives.component.css'],
})
export class DirectivesComponent {
  isAccepted: boolean = false;
  changeState(){
    this.isAccepted=! this.isAccepted
  }

  tracks: string[] = ['DotNet', 'Mearn', 'PHP', 'Python', '3D'];

   track: string = 'Choose any option';


//   myColor = "yellow";
// }
}