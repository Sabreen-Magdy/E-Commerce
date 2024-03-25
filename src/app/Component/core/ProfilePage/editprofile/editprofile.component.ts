import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-editprofile',
  templateUrl: './editprofile.component.html',
  styleUrls: ['./editprofile.component.css']
})
export class EditprofileComponent {

  editProfileForm : FormGroup;

  constructor(){
    this.editProfileForm = new FormGroup({
      name: new FormControl(
        "",
        [
          Validators.required,
          Validators.minLength(5),
          Validators.pattern('[\u0600-\u06FF ,]+')
        ]
      ),
      email: new FormControl(
        "",
        [
          Validators.required,
          Validators.pattern(/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/)
        ]
      ),
      phone : new FormControl(
        "",
        [
          Validators.pattern(/^(010|012|015)[0-9]{8}$/)
        ]
      ),
      password : new FormControl (
        "",
        [
          Validators.required,
          Validators.minLength(10),

        ]
      ),
      
      address : new FormControl (
        "",
        [
          Validators.minLength(10),
          Validators.pattern('[\u0600-\u06FF ,]+')


        ]
      ),
    }
    );
  }
 
   enter(e:Event){
    console.log(this.editProfileForm.valid);
   }

 
  get namecontrol(){
    return this.editProfileForm.get('name')
  }
  get emailcontrol(){
    return this.editProfileForm.get('email')
  }
  get phonecontrol(){
    return this.editProfileForm.get('phone')
  }
  get passwordcontrol(){
    return this.editProfileForm.get('password')
  }
  get addresscontrol(){
    return this.editProfileForm.get('address')
  }
  
}
