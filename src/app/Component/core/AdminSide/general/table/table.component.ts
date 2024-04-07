import { Icolor } from './../../../../../models/icolor';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Isize } from 'src/app/models/isize';
import { ColorServiceService } from 'src/app/services/color-service.service';
import { SizeService } from 'src/app/services/size.service';
import Swal from 'sweetalert2';
import * as namer from 'color-namer';

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
  p:number =1;
  s:number =1;
  waitingClr : boolean = true;
  noclr : boolean = false;
  waitingSize : boolean = true;
  noSize : boolean = false;
  btnsizeForm : string = "اضف";
  titlesizeForm : string = "اضافة حجم";

  btncolorForm : string = "اضف";
  titlecolorForm : string = "اضافة لون";
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
  editColorSub : Subscription | undefined;
  allSizeSubscription : Subscription | undefined;
  addSizeSub : Subscription | undefined;
  editSizeSub : Subscription | undefined;

  getallcolor(){
    this.allcolorSubscription = this.clrService.getAllColor().subscribe({
      next: (data) => {
        this.colorList =data;
        this.waitingClr = false;
        if (data.length ==0){
          this.noclr = true
        }
      },
      error : (e) => {
        console.log("error");
        console.log(e);
        this.noclr = true;
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
    this.btncolorForm = "تعديل";
    this.titlecolorForm = "تعديل لون"
    this.selectedColor = Color;
    this.setColorFormValues(Color);
    this.toggleColorForm();
  }
  setColorName() {
    let hexColor = this.colorForm.get('code')?.value;
    let names = namer(hexColor);
    let colorName = names.pantone[0].name; // or any other list like 'ntc', 'html', etc., based on your requirement
    this.colorForm.get('name')?.setValue(colorName);
  }
  subColor(e:Event) {
    e.preventDefault();
    if (this.colorForm.valid){
      const name = this.colorForm.get('name')?.value;
      const code = this.colorForm.get('code')?.value;
      const colorString : string = code.toUpperCase();
      if (this.selectedColor){
        console.log(this.selectedColor.id);
        var editColor : Icolor = {
          id: this.selectedColor.id,
          code: code,
          name: name
        }
        this.editColorSub = this.clrService.editcolor(editColor).subscribe({
          next: () => {
            this.getallcolor();
          },
          error : (e) =>{
            console.log("ERROR when edit Color " + e);
          }
        })
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
          Swal.fire({
            title: 'توجد منتجات بذلك اللون لا يمكنك حذفه حتى الإنتهاء منها',
            confirmButtonColor: '#198754', // Change this to the color you prefer
          });
          console.error('Error deleteing color:', error);
        }
      }
    )
  }

  toggleColorForm(){
    console.log("Seleced" + this.selectedColor);
    var form = document.getElementById("colorForm");
    form?.classList.add('model-show');
  }

  closeColorForm(){
    this.btncolorForm = "اضف";
    this.titlecolorForm = "اضافة لون";
    this.colorForm.reset();
    if (this.selectedColor) {
      this.selectedColor = undefined
    }
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
        this.waitingSize = false;
        if (data.length==0){
          this.noSize = true
        }
      },
      error : (e) => {
        this.noSize = true;
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
        console.log(this.selectedSize);
        var editSized :Isize ={
          id: this.selectedSize.id,
          size: this.sizeForm.get('size')?.value
        }
        this.editSizeSub = this.sizeServ.editSize(editSized).subscribe({
          next: () =>
          {
            console.log('edit succesful');
            this.getallSize();
            this.btnsizeForm = "اضف"
            this.titlesizeForm = "اضافة حجم"
          },
          error : (e) => {
            console.log("Error When edit Size" + e);
          }
        })
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
          Swal.fire({
            title: 'توجد منتجات بذلك الحجم لا يمكنك حذفه حتى الإنتهاء منها',
            confirmButtonColor: '#198754', // Change this to the color you prefer
          });
          console.error('Error deleteing Size:', error);
        }
      }
    )
  }
  toggleSizeForm(){
    console.log("selected" + this.selectedSize);
    var form = document.getElementById("sizeForm");
    form?.classList.add('model-show');
  }
  setSizeFormValues(size: Isize) {
    this.sizeForm.patchValue({
      size: size.size
    });
  }
  editSize(size: Isize) {
    this.titlesizeForm =  "تعديل الحجم";
    this.btnsizeForm = "تعديل"
    this.selectedSize = size;
    this.setSizeFormValues(size);
    this.toggleSizeForm();
  }


  closeSizeForm(){
    this.sizeForm.reset();
    var form = document.getElementById("sizeForm");
    form?.classList.remove('model-show');
    this.showerro = false;
    if(this.selectedSize){
      this.selectedSize = undefined;
    }
    this.btnsizeForm = "اضف"
    this.titlesizeForm = "اضافة حجم"
  }
}
