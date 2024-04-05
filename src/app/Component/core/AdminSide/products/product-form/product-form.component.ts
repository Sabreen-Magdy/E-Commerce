import { ColoredProduct, coloredProduct2 } from './../../../../../models/colored-product';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl, FormArray, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { IProductAddForm, IProductVariant } from 'src/app/models/i-product-variant';
import { Icolor } from 'src/app/models/icolor';
import { Isize } from 'src/app/models/isize';
import { ICategory } from 'src/app/models/i-category';
import { ColorServiceService } from 'src/app/services/color-service.service';
import { SizeService } from 'src/app/services/size.service';
import { CategoryService } from 'src/app/services/category.service';
import { Subscription } from 'rxjs';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ProductFormService } from 'src/app/services/product-form.service';
import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';





interface option {
  item_id: number,
  item_text: string

}

interface varienty {
  colorname: string,
  colorcode: string,
  sizename: string
}

interface coloryy {
  id :number;
  name: string,
  code: string,
}
@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class ProductFormComponent implements OnInit {


  selectedimgUrl: string[] = []
  showerroM: boolean = false;
  showerroC: boolean = false;
  showerroS: boolean = false;
  match : boolean = false;
  selectedFile!: File
  colorList: Icolor[] = [];
  sizeList: Isize[] = [];
  categoryList: ICategory[] = [];
  imagesColor: ColoredProduct[] = [];
  imagesColor2: coloredProduct2 [] = [];
  uploadedImage: string = "";
  nameofColorforImage: coloryy[] = [];
  datafColorandSizeCari: varienty[] = [];
  productVariants: IProductVariant[] = [];
  dropdownList: option[] = [];
  selectedItems: option[] = [];
  dropdownSettings: IDropdownSettings = {};

  btnText :string = "اضف";
  waitingDoneSend : boolean = false;

  nowuploadImage : string = "";
  constructor(private http: HttpClient, private sanitizer: DomSanitizer, private clrServ: ColorServiceService, private sizeServ: SizeService, private categServ: CategoryService, private addproductServ: ProductFormService, private myRouter: Router, private actRoute: ActivatedRoute) { }

  ngOnInit() {
    this.getallcolor();
    this.getallSize();
    this.getallcateg();
    this.selectedItems = [];
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'اختيار الكل',
      unSelectAllText: 'عدم اختيار الكل',
      itemsShowLimit: 8,
      // allowSearchFilter: true
    }

  }

  allcolorSubscription: Subscription | undefined;
  colorByIdSub: Subscription | undefined;
  allSizeSubscription: Subscription | undefined;
  allCategSubscription: Subscription | undefined;

  getallcolor() {
    this.allcolorSubscription = this.clrServ.getAllColor().subscribe({
      next: (data) => {
        this.colorList = data;
      },
      error: (e) => {
        console.log("error");
        console.log(e);
      }
    })
  }

  getColorById(id: number) {
    this.colorByIdSub = this.clrServ.getcolorByID(id).subscribe({
      next: (data) => { return data }
    })
  }
  getallSize() {
    this.allcolorSubscription = this.sizeServ.getAllSize().subscribe({
      next: (data) => {
        this.sizeList = data;
      },
      error: (e) => {
        console.log("error");
        console.log(e);
      }
    })
  }

  getallcateg() {
    this.allcolorSubscription = this.categServ.getAllCategs().subscribe({
      next: (data) => {
        this.dropdownList = data.map(category => {
          return {
            item_id: category.id,
            item_text: category.name
          };
        }
        )
      },
      error: (e) => {
        console.log("error");
        console.log(e);
      }
    })
  }

  onItemSelect(item: any) {
    console.log(item);
  }
  onSelectAll(items: any) {
    console.log(items);
  }


  getColorNameById(colorId: number): string {
    console.log("hiiiiiiiiiiiiiiiiiiiiiiiiiiii");
    console.log(this.colorList);
    for (let i = 0; i < this.colorList.length; i++) {
      const clr = this.colorList[i];
      console.log(clr);
      console.log(clr.id);
      console.log(colorId);
      if (clr.id == colorId) {
        console.log(clr);
        console.log("done");
        return clr.name;
      }
    }
    return 'Unknown Color';
  }
  getSizeNameById(sizeId: number): string {
    console.log("hiiiiiiiiiiiiiiiiiiiiiiiiiiii");
    console.log(this.colorList);
    for (let i = 0; i < this.sizeList.length; i++) {
      const siz = this.sizeList[i];
      if (siz.id == sizeId) {

        return siz.size;
      }
    }
    return 'Unknown Color';
  }

  getColorCodeById(colorId: number): string {
    const color = this.colorList.find(c => c.id == colorId);
    return color ? color.code : 'Unknown Color';
  }



  productForm: FormGroup = new FormGroup({
    nameproduct: new FormControl('', [Validators.required, Validators.pattern('[\u0600-\u06FF ,]+'), Validators.minLength(5)]),
    categoryproduct: new FormControl('', [Validators.required]),
    descriptionProduct: new FormControl('', [Validators.required, Validators.minLength(7), Validators.pattern('[\u0600-\u06FF ,\n]+')
    ])
  })

  get nameproductcontrol() {
    return this.productForm.get('nameproduct')
  }
  get categoryproductcontrol() {
    return this.productForm.get('categoryproduct')
  }
  get descriptionProductcontrol() {
    return this.productForm.get('descriptionProduct')
  }


  picForm: FormGroup = new FormGroup({
    colorId: new FormControl('', Validators.required),
    image: new FormControl(null, [Validators.required, this.validateImageFile()])
  });

  get colorPicFormcontrol() {
    return this.picForm.get('colorId')
  }

  get imagePicFormcontrol() {
    return this.picForm.get('image')
  }

  onFileSelected(event: any) {
    const inputElement = event.target ;
    if (inputElement && inputElement.files && inputElement.files.length > 0) {
      const file = inputElement.files[0];
      this.picForm.patchValue({ image: file });
      const imageControl = this.picForm.get('image');
      if (imageControl) {
        imageControl.updateValueAndValidity();
      }
      const reader = new FileReader();
      console.log(reader);
      reader.onloadend = () => {
        const base64File = reader.result as string;
        console.log(base64File);
        this.nowuploadImage = base64File;
      };
      if (file) {
        reader.readAsDataURL(file);
        console.log(file);
      }

    }
  }
   validateImageFile(): ValidatorFn {
    return (control: AbstractControl): {[key: string]: any} | null => {
      const file = control.value;
      if (file) {
        const extension = file.name.split('.').pop().toLowerCase();
        const validExtensions = ['png', 'jpg', 'jpeg'];
        if (!validExtensions.includes(extension)) {
          // If file extension is not valid, return error object
          return { invalidFileType: true };
        }
      }
      // If file is valid or no file, return null
      return null;
    };
  }
  productVariantForm: FormGroup = new FormGroup({
    color: new FormControl('', [Validators.required]),
    size: new FormControl('', [Validators.required]),
    price: new FormControl('', [Validators.required, Validators.min(70)]),
    quantiy: new FormControl('', [Validators.required, Validators.min(5)]),
    disceount: new FormControl('', [Validators.max(25), Validators.min(0)]),
  });

  get colorvariantcontrol() {
    return this.productVariantForm.get('color')
  }
  get sizevariantcontrol() {
    return this.productVariantForm.get('size')
  }
  get pricevariantcontrol() {
    return this.productVariantForm.get('price')
  }
  get quantiyVariantcontrol() {
    return this.productVariantForm.get('quantiy')
  }
  get disceountvariantcontrol() {
    return this.productVariantForm.get('disceount')
  }


  /* Toggle */
  togglePhoto() {
    var form = document.getElementById("photoForm");
    form?.classList.add('model-show');

  }

  addPhoto(e: Event) {
    e.preventDefault();
    if (this.picForm.valid) {
      const imageColor: ColoredProduct = {
        colorId: this.picForm.get('colorId')?.value,
        image: this.picForm.get('image')?.value
      }
      const imageColor2 : coloredProduct2 = {
        colorId:  this.picForm.get('colorId')?.value,
        image: this.nowuploadImage
      }
      this.imagesColor.push(imageColor);
      this.imagesColor2.push(imageColor2);
      const colornameCode: coloryy = {
        id :this.picForm.get('colorId')?.value,
        name: this.getColorNameById(this.picForm.get('colorId')?.value),
        code: this.getColorCodeById(this.picForm.get('colorId')?.value,)
      }
      const reader = new FileReader();
      reader.onload = () => {
        // Assign the data URL to a property in your component
        if (typeof reader.result === 'string') {
        this.selectedimgUrl.push(reader.result);}
      };
      // Read the file as a data URL
      reader.readAsDataURL(imageColor.image);

      this.nameofColorforImage.push(colornameCode);

      this.picForm.reset();
      this.closePhoto()

    } else {
      this.showerroC = true
    }

  }

  closePhoto() {
    var form = document.getElementById("photoForm");
    form?.classList.remove('model-show');
    this.showerroC = false;
  }

  toggleVarient() {
    var form = document.getElementById("VariantForm");
    form?.classList.add('model-show2');
  }
  closeVarient() {
    this.productVariantForm.reset();
    this.showerroS = false;
    var form = document.getElementById("VariantForm");
    form?.classList.remove('model-show2');
  }

  addVariant(e: Event) {
    e.preventDefault();
    this.match = false;
    if (this.productVariantForm.valid) {

      const vary: IProductVariant = {
        colorId: this.productVariantForm.get('color')?.value,
        unitPrice: this.productVariantForm.get('price')?.value,
        discount: this.productVariantForm.get('disceount')?.value / 100,
        quantity: this.productVariantForm.get('quantiy')?.value,
        sizeId: this.productVariantForm.get('size')?.value
      }

      for (let x of this.productVariants){
        if (x.sizeId == vary.sizeId && x.colorId == vary.colorId){

          this.match = true;
          break;
        }
      }
      if (!this.match){
      this.productVariants.push(vary);
      const data: varienty = {
        colorname: this.getColorNameById(this.productVariantForm.get('color')?.value),
        colorcode: this.getColorCodeById(this.productVariantForm.get('color')?.value),
        sizename: this.getSizeNameById(this.productVariantForm.get('size')?.value)
      }

      this.datafColorandSizeCari.push(data)
      this.closeVarient();
    }}else {
      this.showerroS = true;
    }

  }

  deleteRow(index: number) {
    this.productVariants.splice(index, 1); // Remove item from productVariants list
    this.datafColorandSizeCari.splice(index, 1);
  }

  deleteImage(index: number) {
    let colorid = this.nameofColorforImage[index].id;
    this.selectedimgUrl.splice(index, 1);
    this.nameofColorforImage.splice(index, 1);
    this.imagesColor2.splice(index,1);
    
    for (let i = this.productVariants.length - 1; i >= 0; i--) {
      if (this.productVariants[i].colorId === colorid) {
        this.productVariants.splice(i, 1);
        this.datafColorandSizeCari.splice(i,1)
      }
    }
  }
  onsumbit() {
    if (this.productForm.valid && this.imagesColor.length > 0 && this.productVariants.length > 0) {

      this.waitingDoneSend = true;
      this.btnText = ""
      const formData = new FormData();
      const newProduct:IProductAddForm = {
        sallerId: 1,
        name: this.productForm.get('nameproduct')?.value,
        description: this.productForm.get('descriptionProduct')?.value,
        categories: this.selectedItems.map(item => item.item_id),
        images: this.imagesColor2,
        productVariants: this.productVariants
      }
      console.log(newProduct);
      // formData.append('SallerId', '1');
      // formData.append('Name', this.productForm.get('nameproduct')?.value);
      // formData.append('Description', this.productForm.get('descriptionProduct')?.value);
      // for (let i = 0; i < this.selectedItems.length; i++) {
      //   formData.append('Categories', this.selectedItems[i].item_id.toString());
      // }
      // for (let i = 0; i < this.imagesColor.length; i++) {
      //   formData.append('Image', this.imagesColor[i].image);
      // }
      // for (let i = 0; i < this.imagesColor.length; i++) {
      //   formData.append('ColorId', this.imagesColor[i].colorId.toString());
      // }
      // // formData.append('Categories', this.selectedItems.map(item => item.item_id));
      // // formData.append('Image', this.imagesColor.map(item => item.image));
      // for (let i = 0; i < this.productVariants.length; i++) {
      //   formData.append('ProductVariants_ColorId', this.productVariants[i].colorId.toString());
      // }
      // for (let i = 0; i < this.productVariants.length; i++) {
      //   formData.append('ProductVariants_UnitPrice', this.productVariants[i].unitPrice.toString());
      // }
      // for (let i = 0; i < this.productVariants.length; i++) {
      //   formData.append('ProductVariants_Discount', this.productVariants[i].discount.toString());
      // }
      // for (let i = 0; i < this.productVariants.length; i++) {
      //   formData.append('ProductVariants_Quantity', this.productVariants[i].quantity.toString());
      // }
      // for (let i = 0; i < this.productVariants.length; i++) {
      //   formData.append('ProductVariants_SizeId', this.productVariants[i].sizeId.toString());
      // }

      this.addproductServ.addProduct(newProduct).subscribe({
        next: (e) => {
          console.log("Donnnne", e)
          this.myRouter.navigate(['/admin/product']);
        },
        //error: (e) => console.log(e), 
      })
    } else {
      this.showerroM = true;
    }


  }


}
