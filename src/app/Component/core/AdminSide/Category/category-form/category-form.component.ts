import { ICategory } from './../../../../../models/i-category';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.css']
})
export class CategoryFormComponent implements OnInit {

  categoryForm : FormGroup;
  id : number = 0 ;
  showerror : boolean = false;
  isedit : boolean = false;
  constructor( 
    private cateService : CategoryService,
    private myRouter: Router,
    private actRoute: ActivatedRoute
    )
    {
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


  getCategIdSub : Subscription | undefined;
  addCategorySub : Subscription | undefined;
  editCategorySub : Subscription | undefined;

  ngOnInit(): void {
    this.id = this.actRoute.snapshot.params['id'];
    this.getCategIdSub = this.cateService.getById(this.id).subscribe(
      {
        next : (data) => {
          this.isedit = true;
          this.categoryForm.controls['categoryname'].setValue(data.name);
          this.categoryForm.controls['categoryicon'].setValue(data.icon);
          this.categoryForm.controls['categorydescription'].setValue(data.description);
        },
        error : (e) =>{
          console.log("ERROR happen when fetch data");
        }
      }
    )
  }
 
  cateFormSub(e: Event) {
    e.preventDefault();
    if (this.categoryForm.valid) {
      if (this.id) {
        console.log(this.id);
        var editCategory  ={
          name: this.categoryForm.get('categoryname')?.value,
          icon: this.categoryForm.get('categoryicon')?.value,
          description: this.categoryForm.get('categorydescription')?.value
        }
        this.editCategorySub = this.cateService.editCategory(this.id,editCategory).subscribe({
          next: () => {
            this.myRouter.navigate(['/admin/category']);
          },
          error: (error) => {
            console.error('Error editing category:', error);
          }
        })
        console.log("Update Here");
      } else {
        const newCateg = {
          name: this.categoryForm.get('categoryname')?.value,
          icon: this.categoryForm.get('categoryicon')?.value,
          description: this.categoryForm.get('categorydescription')?.value
        };

        this.addCategorySub = this.cateService.addCategory(newCateg).subscribe({
          next: () => {
            this.myRouter.navigate(['/admin/category']);
          },
          error: (error) => {
            console.error('Error adding category:', error);
          }
        });
      }
    } else {
      this.showerror = true;
    }
  }


}
