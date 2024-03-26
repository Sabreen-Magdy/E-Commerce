import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ICategory } from 'src/app/models/i-category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-table',
  templateUrl: './category-table.component.html',
  styleUrls: ['./category-table.component.css']
})
export class CategoryTableComponent implements OnInit {
  categoryList : ICategory[] =[];

  constructor(private catService : CategoryService){}
  ngOnInit(): void {
    this.getallCategory();
  }

  allCategSubscriptipn : Subscription | undefined;

  getallCategory(){
    this.allCategSubscriptipn = this.catService.getAllCategs().subscribe({
      next : (data) => {
        console.log("HIIIIII");
        console.log(data);
        this.categoryList=data;
      },
      error : (e) => {
        console.log("error when get Category:" + e);
      }
    })
  }

  deleteCategory (id :number){
    this.catService.deleteCategory(id).subscribe({
      next: () => {this.getallCategory();},
        error: (error) => {
          console.error('Error deleteing category:', error);
        }
    })
  }

}
