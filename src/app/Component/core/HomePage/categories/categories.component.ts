import { Component, OnInit } from '@angular/core';
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

  constructor( private cateServ :CategoryService){}
  ngOnInit(): void {
    this.getAllCategory();
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
