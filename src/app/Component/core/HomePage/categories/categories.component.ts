import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryScaleOptions } from 'chart.js';
import { Subscription } from 'rxjs';
import { ICategory } from 'src/app/models/i-category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  categoryList : ICategory[] =[];
  categoryName : string = "";
  constructor( private cateServ :CategoryService , private activeRoute : ActivatedRoute){}
  ngOnInit(): void {
    this.getAllCategory();
    this.activeRoute.params.subscribe(params => {
      this.categoryName = params['catgoryname'];
      console.log(this.categoryName); // Convert the parameter to a number
     
     
    })
  }

  allCategorySub : Subscription | undefined;

   getAllCategory(){

    this.allCategorySub = this.cateServ.getAllCategs().subscribe({
      next: (data) => {
        console.log(data);
        this.categoryList = data
      },
      error : (e)=>{
        console.log("ERROR with fetchData" + e);
      }
    })

  }

}
