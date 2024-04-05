import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ICategory } from 'src/app/models/i-category';
import { CategoryService } from 'src/app/services/category.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-category-table',
  templateUrl: './category-table.component.html',
  styleUrls: ['./category-table.component.css']
})
export class CategoryTableComponent implements OnInit {
  categoryList : ICategory[] =[];
  p:number = 1;
  waiting : boolean = true;
  noitem : boolean = false;

  constructor(private catService : CategoryService){}
  ngOnInit(): void {
    this.getallCategory();
  }

  allCategSubscriptipn : Subscription | undefined;

  getallCategory(){
    this.allCategSubscriptipn = this.catService.getAllCategs().subscribe({
      next : (data) => {
        if (data.length ==0 ){
          this.noitem = true;
        }
        console.log("HIIIIII");
        console.log(data);
        this.categoryList=data;
        this.waiting = false;
      },
      error : (e) => {
        console.log("error when get Category:" + e);
        this.noitem = true;
      }
    })
  }

  deleteCategory (id :number){
    this.catService.deleteCategory(id).subscribe({
      next: () => {this.getallCategory();},
        error: (error) => {
          // Swal.fire('لا يمكنك حذف الفئة قم بإفراغها أولا!');
          Swal.fire({
            title: 'لا يمكنك حذف الفئة قم بإفراغها أولا!',
            confirmButtonColor: '#198754', // Change this to the color you prefer
          });
          console.error('Error deleteing category:', error);
        }
    })
  }

}
