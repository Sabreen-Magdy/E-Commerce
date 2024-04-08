import { FormControl, FormGroup, Validators } from '@angular/forms';
import {
  ICategoryProduct,
  IcoloredImage,
  IProductDetilas,
  IupdateDetials,
  IVarient,
} from './../../../../../models/edit-product';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { EditProductService } from 'src/app/services/edit-product.service';
import { ICategory } from 'src/app/models/i-category';
import { CategoryService } from 'src/app/services/category.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-all-product-detials',
  templateUrl: './all-product-detials.component.html',
  styleUrls: ['./all-product-detials.component.css'],
})
export class AllProductDetialsComponent implements OnInit {
  constructor(
    private editServ: EditProductService,
    private _router: Router,
    private actRoute: ActivatedRoute,
    private categSer : CategoryService,
  ) {}

  productId: number = 0;

  loadDETIALS : boolean = true;
  loadImag : boolean = true;
  LOadvariant : boolean = true;
  loadCategory : boolean = true;

  detilasObject: IProductDetilas = {
    id: 0,
    name: '',
    avgRating: 0,
    numberReviews: 0,
    description: '',
  };
  coloredProduct: IcoloredImage[] = [];
  variantProduct: IVarient[] = [];
  CategoryProduct: ICategoryProduct[] = [];
  ALLCategory : ICategory [] = [];
  showerroCat : boolean = false;
  showerrordetials : boolean = false;

  generateNumberArray(limit: number): number[] {
    return Array.from({length: limit}, (_, index) => index + 1);
  }


  ngOnInit(): void {
    this.productId = this.actRoute.snapshot.params['id'];
    console.log(this.productId);
    this.getAllDetials();
    this.getAllCategoryProduct();
    this.getAllColoredProd();
    this.getAllVariant();
  }

  getDetialsSub: Subscription | undefined;
  getVariantSub: Subscription | undefined;
  getCategorySub: Subscription | undefined;
  getColoredProdSub: Subscription | undefined;

  deleteVariantSub: Subscription | undefined;
  deleteCategorySub: Subscription | undefined;
  deleteColoredProdSub: Subscription | undefined;

  updateDetialsSub : Subscription | undefined;
  addCategorySub :Subscription | undefined;
  gatAllCatrgory :Subscription | undefined;

  getAllDetials() {
    this.getDetialsSub = this.editServ
      .getonlyDetailsById(this.productId)
      .subscribe({
        next: (data) => {
          console.log("productDrtials",data);
          data.avgRating = Math.floor(data.avgRating);
          this.detilasObject = data;
          this.loadDETIALS = false;
        },
        error: (e) => {
          console.log('ERROR when fetch Detials');
          console.log(e);
        },
      });
  }
  getAllCategoryProduct() {
    this.getCategorySub = this.editServ
      .getCategoryById(this.productId)
      .subscribe({
        next: (data) => {
          console.log("category", data);
          this.CategoryProduct = data;
          this.loadCategory = false;
          this.getAllcategory();
        },
        error: (e) => {
          console.log('ERROR when Delete Product');
          console.log(e);
        },
      });
  }
  getAllColoredProd() {
    this.getColoredProdSub = this.editServ
      .getProductImages(this.productId)
      .subscribe({
        next: (data) => {
          console.log("colored" + data);
          this.coloredProduct = data;
          this.loadImag = false;
        },
        error: (e) => {
          console.log('ERROR when fetch colored Prod');
          console.log(e);
        },
      });
  }
  getAllVariant() {
    this.getVariantSub = this.editServ
      .getVariantsById(this.productId)
      .subscribe({
        next: (data) => {
          console.log("variant" , data);
          this.variantProduct = data;
          this.LOadvariant = false;
        },
        error: (e) => {
          console.log('ERROR when fetch Detials');
          console.log(e);
        },
      });
  }

  getAllcategory (){
    this.getCategorySub = this.categSer.getAllCategs().subscribe({
      next : (d)=>{
        for (let i = d.length - 1; i >= 0; i--) {
          for (let x of this.CategoryProduct) {
            if (d[i].id === x.id) {
              d.splice(i, 1);
              break;
            }
          }
        }

        this.ALLCategory = d;
      }
    })
  }

  deleteCategory(id: number) {
    if (this.coloredProduct.length > 1) {
      this.deleteCategorySub = this.editServ
        .deleteCatgoryofProduct(this.productId, id)
        .subscribe({
          next: (d) => {
            console.log(d);
            // this.getAllColoredProd();
          },
          error: (e) => {
            console.log('ERROR when delete product Category');
            console.log(e);
          },
        });
    } else {
      console.log('You Should Have at least one Category');
    }
  }

  deleteColoredProd(id: number) {
    Swal.fire({
      title: 'هل أنت متأكد من أنك تريد حذف المنتج؟!',
      confirmButtonColor: '#198754', // لون زر التأكيد
      confirmButtonText: 'تأكيد',
      cancelButtonText: 'إلغاء',
      showCancelButton: true,
      cancelButtonColor: '#dc3545' // لون زر الإلغاء
    }).then((result) => {if (result.isConfirmed) {
    this.deleteColoredProdSub = this.editServ
      .deleteProductImages(id)
      .subscribe({
        next: (d) => {
          console.log(d);
          this.getAllColoredProd();
          this.getAllVariant();
        },
        error: (e) => {
          console.log('ERROR when delete product Image');
          console.log(e);
        },
      });}})
  }

  deleteVariantProd(id: number, index : number) {
    let condition : boolean = this.variantProduct[index].quantity > 0;
    if (true){
      Swal.fire({
        
        title: condition? 'المنتج بيه كميات متوفرة \n\nهل أنت متأكد من أنك تريد حذفه؟!' : 'المنتج لا يوجد بيه كميات  \n\nلكن هل انت متأكد من انك تريد حذفه',
        confirmButtonColor: '#198754', // لون زر التأكيد
        confirmButtonText: 'تأكيد',
        cancelButtonText: 'إلغاء',
        showCancelButton: true,
        cancelButtonColor: '#dc3545' // لون زر الإلغاء
      }).then((result) => {if (result.isConfirmed) {
        this.deleteVarient(id);
      }})
    }else{
      Swal.fire({
        title:'هذا المنتج لا يوجد بيه كميات متوفرة سيتم حذفه الان',
        timer:2000
      });
      this.deleteVarient(id);
    }
   
  }
  deleteVarient(id : number){
    this.deleteVariantSub = this.editServ.deleteVariant(id).subscribe({
      next: (d) => {
        console.log(d);
        this.getAllVariant();
      },
      error: (e) => {
        
        console.log('ERROR when delete product variant');
        console.log(e);
      },
    });
  }
  CategoryForm : FormGroup = new FormGroup({
    category: new FormControl ("", [Validators.required])
  })

  get categorycontrol(){
    return this.CategoryForm.controls['category']
  }


  subCategoey(e:Event) {
    e.preventDefault();
    if (this.CategoryForm.valid){

      const categoryId = this.CategoryForm.get('category')?.value;

        this.addCategorySub = this.editServ.addCategoryToprodutc(this.productId, categoryId).subscribe(
          {
            next: () => {
              this.getAllCategoryProduct();
              this.closeSizeForm();
            },
            error: (error) => {
              console.error('Error adding Size:', error);
            }
          }
        );
      }

      // this.closeSizeForm();
    else{
      this.showerroCat =true
    }




  }
  toggleSizeForm(){
    var form = document.getElementById("CategForm");
    form?.classList.add('model-show');
  }

  closeSizeForm(){
    this.CategoryForm.reset();
    var form = document.getElementById("CategForm");
    form?.classList.remove('model-show');
    this.showerroCat = false;


  }


  productForm: FormGroup = new FormGroup({
    nameproduct: new FormControl(this.detilasObject.name, [Validators.required, Validators.pattern('[\u0600-\u06FF ,]+'), Validators.minLength(5)]),
    descriptionProduct: new FormControl(this.detilasObject.description, [Validators.required, Validators.minLength(7), Validators.pattern('[\u0600-\u06FF ,\n]+')
    ])
  })

  get nameproductcontrol() {
    return this.productForm.get('nameproduct')
  }
  get descriptionProductcontrol() {
    return this.productForm.get('descriptionProduct')
  }

  subUpdate(e:Event){
    e.preventDefault;
    if (this.productForm.valid){
      const Updat : IupdateDetials ={
        name:this.productForm.get('nameproduct')?.value ,
        description: this.productForm.get('descriptionProduct')?.value
      }
      this.updateDetialsSub = this.editServ.updateDetials(this.productId,Updat).subscribe({
        next : (d)=>{
          console.log("done");
          this.getAllDetials();
          this.closeDetialsForm();
        },
        error : (e) => {
          console.log("ERROR when Update Detials");
          console.log(e);

        }
      })


    }else{
      this.showerrordetials = true;
    }

  }

  assignDatatoFormDetials(){
    this.productForm.controls['nameproduct'].setValue(this.detilasObject.name)
    this.productForm.controls['descriptionProduct'].setValue(this.detilasObject.description)
  }

  toggleDetialsForm(){
    this.assignDatatoFormDetials();
    var form = document.getElementById("detialsForm");
    form?.classList.add('model-show');
  }

  closeDetialsForm(){
    this.CategoryForm.reset();
    var form = document.getElementById("detialsForm");
    form?.classList.remove('model-show');
    this.showerrordetials = false;


  }
}
