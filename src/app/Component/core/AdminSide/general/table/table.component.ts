import { Icolor } from './../../../../../models/icolor';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Isize } from 'src/app/models/isize';
import { ColorServiceService } from 'src/app/services/color-service.service';
import { SizeService } from 'src/app/services/size.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit{
  colorList: Icolor[] =[];
  sizeList: Isize[] =[];
  showerro : boolean = false;
  selectedSize: Isize | undefined;
  selectedColor: Icolor | undefined;

  colorForm : FormGroup = new FormGroup({
    name : new FormControl("",[Validators.required, Validators.minLength(3)]),
    code : new FormControl("",[Validators.required])
  })
  

  

  get colornamecontrol(){
    return this.colorForm.controls['name']
  }
  get colorcodecontrol(){
    return this.colorForm.controls['code']
  }

  sizeForm : FormGroup = new FormGroup({
    size : new FormControl ("", [Validators.required])
  })

  get sizecontrol(){
    return this.sizeForm.controls['size']
  }
  constructor(private clrService: ColorServiceService,private sizeServ: SizeService){}
  ngOnInit(): void {
    this.getallcolor();
    this.getallSize();
  }
  

  allcolorSubscription : Subscription | undefined;
  addColorSub : Subscription | undefined;
  allSizeSubscription : Subscription | undefined;
  addSizeSub : Subscription | undefined;

  getallcolor(){
    this.allcolorSubscription = this.clrService.getAllColor().subscribe({
      next: (data) => {
        this.colorList =data;
      },
      error : (e) => {
        console.log("error");
        console.log(e);
      }
    })
  }
  setColorFormValues(Color: Icolor) {
    this.colorForm.patchValue({
      name : Color.name,
      code : Color.code
    });
  }
  editColor(Color: Icolor) {
    this.selectedColor = Color;
    this.setColorFormValues(Color);
    this.toggleColorForm();
  }

  subColor(e:Event) {
    e.preventDefault();
    if (this.colorForm.valid){
      const name = this.colorForm.get('name')?.value;
      const code = this.colorForm.get('code')?.value;
      const colorString : string = code.toUpperCase();
      if (this.selectedColor){
        console.log("Update Here");
      }
      else{
        this.addColorSub = this.clrService.addcolor(name,colorString).subscribe(
          {
            next: () => {this.getallcolor();},
            error: (error) => {
              console.error('Error adding color:', error);
            }
          }
        );
      }
  
      this.closeColorForm();
    }else{
      this.showerro = true;
    }
  }
  

  deleteColor (id :number){
    this.clrService.deletecolor(id).subscribe(
      {
        next: () => {this.getallcolor();},
        error: (error) => {
          console.error('Error deleteing color:', error);
        }
      }
    )
  }

  toggleColorForm(){
    var form = document.getElementById("colorForm");
    form?.classList.add('model-show');
  }

  closeColorForm(){
    this.colorForm.reset();
    var form = document.getElementById("colorForm");
    form?.classList.remove('model-show');
    this.showerro = false;
  }

  getallSize(){
    this.allSizeSubscription = this.sizeServ.getAllSize().subscribe({
      next: (data) => {
        console.log("hiiii");
        console.log(data);
        this.sizeList =data;
      },
      error : (e) => {
        console.log("error");
        console.log(e);
      }
    })

    
   
  }

  subSize(e:Event) {
    e.preventDefault();
    if (this.sizeForm.valid){
      const size = this.sizeForm.get('size')?.value;
      
      if (this.selectedSize) {
        // If a size is selected, update it instead of adding a new one
        console.log("update herrre");;
      }else{
        this.addSizeSub = this.sizeServ.addsize(size).subscribe(
          {
            next: () => {this.getallSize();},
            error: (error) => {
              console.error('Error adding Size:', error);
            }
          }
        );
      }
      
      this.closeSizeForm();
    }else{
      this.showerro =true
    }

    
  }

  deleteSize (id :number){
    this.sizeServ.deletesize(id).subscribe(
      {
        next: () => {this.getallSize();},
        error: (error) => {
          console.error('Error deleteing Size:', error);
        }
      }
    )
  }
  toggleSizeForm(){
    var form = document.getElementById("sizeForm");
    form?.classList.add('model-show');
  }
  setSizeFormValues(size: Isize) {
    this.sizeForm.patchValue({
      size: size.size
    });
  }
  editSize(size: Isize) {
    this.selectedSize = size;
    this.setSizeFormValues(size);
    this.toggleSizeForm();
  }


  closeSizeForm(){
    this.colorForm.reset();
    var form = document.getElementById("sizeForm");
    form?.classList.remove('model-show');
    this.showerro = false;
  }
}
