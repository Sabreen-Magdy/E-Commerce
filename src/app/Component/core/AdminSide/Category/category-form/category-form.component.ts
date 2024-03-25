import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.css']
})
export class CategoryFormComponent {

  categoryForm : FormGroup;

  constructor(){
    this.categoryForm = new FormGroup({
      categoryname: new FormControl('',[Validators.required,Validators.pattern('[\u0600-\u06FF ,]+'),Validators.minLength(3)]),
    categoryicon: new FormControl('',[Validators.required]),
    categorydescription : new FormControl('',[Validators.required, Validators.minLength(7),Validators.pattern('[\u0600-\u06FF ,\n]+')
    ])})
  }

  get categorynamecontrol (){
    return this.categoryForm.get('categoryname')
  }
  get categoryiconcontrol (){
    return this.categoryForm.get('categoryicon')
  }
  get categorydescriptioncontrol (){
    return this.categoryForm.get('categorydescription')
  }
}
