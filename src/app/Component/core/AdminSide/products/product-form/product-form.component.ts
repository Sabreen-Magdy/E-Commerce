import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';

interface coloredProduct {
  Colorname: string;
  colorCode: string;
  imgSrcs: string[];
}

interface productVariant {
  color: string;
  size: string;
  price: number;
  quantiy: number;
  disceount: number;
}

interface option {
  item_id:number,
  item_text:string

}
@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class ProductFormComponent implements OnInit {
  imagesColor: coloredProduct[] = [];
  uploadedImages: string[] = [];
  productVariants: productVariant[] = [];
  dropdownList:option[] = [];
  selectedItems:option[] = [];
  dropdownSettings:IDropdownSettings = {};
  constructor() {}
  ngOnInit() {
    this.dropdownList = [
      { item_id: 1, item_text: 'رجالي' },
      { item_id: 2, item_text: 'حريمي' },
      { item_id: 3, item_text: 'عام' },
      { item_id: 4, item_text: 'اطفال' },
      { item_id: 5, item_text: 'احذية' }
    ];
    this.selectedItems = [
      { item_id: 3, item_text: 'عام' },
      { item_id: 4, item_text: 'اطفال' }
    ];
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
  onItemSelect(item: any) {
    console.log(item);
  }
  onSelectAll(items: any) {
    console.log(items);
  }

  handleFileInput(event: any) {
    this.uploadedImages = [];
    const files: FileList = event.target.files;
    if (files && files.length > 0) {
      for (let i = 0; i < files.length; i++) {
        const reader = new FileReader();
        reader.onload = (e: any) => {
          this.uploadedImages.push(e.target.result);
        };
        reader.readAsDataURL(files[i]);
      }
    }
  }

  productForm : FormGroup = new FormGroup({
    nameproduct: new FormControl('',[Validators.required,Validators.pattern('[\u0600-\u06FF ,]+'),Validators.minLength(5)]),
    categoryproduct: new FormControl('',[Validators.required]),
    descriptionProduct : new FormControl('',[Validators.required, Validators.minLength(7),Validators.pattern('[\u0600-\u06FF ,\n]+')
  ])
  })

  get nameproductcontrol (){
    return this.productForm.get('nameproduct')
  }
  get categoryproductcontrol (){
    return this.productForm.get('categoryproduct')
  }
  get descriptionProductcontrol (){
    return this.productForm.get('descriptionProduct')
  }

  picForm: FormGroup = new FormGroup({
    Colorname: new FormControl('', [Validators.required]),
    colorCode: new FormControl('', [Validators.required]),
    imgSrcs: new FormArray([], Validators.required),
  });

  productVariantForm: FormGroup = new FormGroup({
    color: new FormControl('',[Validators.required]),
    size: new FormControl('',[Validators.required]),
    price: new FormControl('',[Validators.required, Validators.min(70)]),
    quantiy: new FormControl('',[Validators.required,Validators.min(5) ]),
    disceount: new FormControl('',[Validators.max(25),Validators.min(0)]),
  });

  get  colorvariantcontrol (){
    return this.productVariantForm.get('color')
  }
  get sizevariantcontrol (){
    return this.productVariantForm.get('size') 
  }
  get pricevariantcontrol (){
    return this.productVariantForm.get('price') 
  }
  get quantiyVariantcontrol (){
    return this.productVariantForm.get('quantiy') 
  }
  get disceountvariantcontrol (){
    return this.productVariantForm.get('disceount') 
  }


  /* Toggle */
  togglePhoto(){
    var form = document.getElementById("photoForm");
    form?.classList.add('model-show');
    
  }
  
  addPhoto(e: Event) {
    e.preventDefault();
    console.log(this.uploadedImages);
    console.log(this.picForm.get('imgSrcs')?.value);

    // Clear the existing values in the imgSrcs FormArray
    const imgSrcsArray = this.picForm.get('imgSrcs') as FormArray;
    while (imgSrcsArray.length !== 0) {
      imgSrcsArray.removeAt(0);
    }

    // Push each uploaded image URL into the FormArray
    this.uploadedImages.forEach((image) => {
      imgSrcsArray.push(new FormControl(image));
    });

    // Create a coloredProduct object with form values
    const colorProd: coloredProduct = {
      Colorname: this.picForm.get('Colorname')?.value,
      colorCode: this.picForm.get('colorCode')?.value,
      imgSrcs: this.picForm.get('imgSrcs')?.value,
    };

    console.log(colorProd);
    this.imagesColor.push(colorProd);
    console.log(this.imagesColor);
    // Reset the form and uploadedImages array
    this.picForm.reset();
    this.uploadedImages = [];
    this.closePhoto();

  }

  closePhoto(){
    var form = document.getElementById("photoForm");
    form?.classList.remove('model-show');
  }
  toggleVarient(){
    var form = document.getElementById("VariantForm");
    form?.classList.add('model-show2');
  }
  closeVarient(){
    this.productVariantForm.reset();
    var form = document.getElementById("VariantForm");
    form?.classList.remove('model-show2');
  }
  
  addVariant(e :Event ){
    e.preventDefault();
    this.productVariants.push(this.productVariantForm.value);
    console.log(this.productVariants);
    this.closeVarient();
  }
}
