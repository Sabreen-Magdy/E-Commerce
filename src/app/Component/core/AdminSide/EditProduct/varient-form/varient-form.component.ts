import { SizeService } from 'src/app/services/size.service';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import {
  IaddVariant,
  IcoloredImage,
  IupdateVariant,
  IVarient,
} from 'src/app/models/edit-product';
import { Icolor } from 'src/app/models/icolor';
import { Isize } from 'src/app/models/isize';
import { ColorServiceService } from 'src/app/services/color-service.service';
import { EditProductService } from 'src/app/services/edit-product.service';

@Component({
  selector: 'app-varient-form',
  templateUrl: './varient-form.component.html',
  styleUrls: ['./varient-form.component.css'],
})
export class VarientFormComponent {
  isedit: boolean = false;
  prodId: number = 0;
  variantid: number = 0;
  showerroS: boolean = false;
  match: boolean = false;
  listColor: Icolor[] = [];
  listSize: Isize[] = [];
  ProductVariantList: IVarient[] = [];
  coloredProductList: IcoloredImage[] = [];
  formTitle :string = "اضافة تفاصيل المنتج";
  btnTitle : string = "اضف";

  constructor(
    private editServ: EditProductService,
    private colorserv: ColorServiceService,
    private sizeServ: SizeService,
    private actRoute: ActivatedRoute,
    private _router: Router
  ) {}
  ngOnInit() {
    this.actRoute.params.subscribe((params) => {
      this.prodId = params['id'];
      this.variantid = params['variantId'];
      console.log(this.prodId);

      if (this.variantid) {
        console.log('edit');
        this.formTitle = "تعديل تفاصيل المنتج"
        this.btnTitle="تعديل"
        this.isedit = true;
        this.getAllVarientProduct();
      } else {
        console.log('add');
        this.getColoerproduct();
        this.getAllVarientProduct();
        this.getALLsize();
      }
    });
  }

  productVariantForm: FormGroup = new FormGroup({
    color: new FormControl('', [Validators.required]),
    size: new FormControl('', [Validators.required]),
    price: new FormControl('', [Validators.required, Validators.min(70)]),
    quantiy: new FormControl('', [Validators.required, Validators.min(5)]),
    disceount: new FormControl('', [Validators.max(25), Validators.min(0)]),
  });

  get colorvariantcontrol() {
    return this.productVariantForm.get('color');
  }
  get sizevariantcontrol() {
    return this.productVariantForm.get('size');
  }
  get pricevariantcontrol() {
    return this.productVariantForm.get('price');
  }
  get quantiyVariantcontrol() {
    return this.productVariantForm.get('quantiy');
  }
  get disceountvariantcontrol() {
    return this.productVariantForm.get('disceount');
  }

  getAllcolorSub: Subscription | undefined;
  getColoredProduct: Subscription | undefined;
  addProductVariantSub: Subscription | undefined;
  getSizeSub: Subscription | undefined;
  getAllVarientProductSub: Subscription | undefined;

  getColoerproduct() {
    this.getAllcolorSub = this.editServ
      .getProductImages(this.prodId)
      .subscribe({
        next: (d) => {
          this.coloredProductList = d;

          this.getALLcolor();
        },
        error: (e) => {
          console.log('ERROR WHEN fetch coloredImag');
          console.log(e);
        },
      });
  }

  getALLcolor() {
    this.getAllcolorSub = this.colorserv.getAllColor().subscribe({
      next: (data) => {
        console.log('all Color', data);
        const filterColor: Icolor[] = [];
        for (let i = data.length - 1; i >= 0; i--) {
          for (let x of this.coloredProductList) {
            if (data[i].code === x.colorCode) {
              filterColor.push(data[i]);
              break;
            }
          }
        }

        console.log('filterColor', filterColor);
        this.listColor = filterColor;
      },
    });
  }

  getALLsize() {
    this.getSizeSub = this.sizeServ.getAllSize().subscribe({
      next: (d) => {
        this.listSize = d;
      },
    });
  }
  getAllVarientProduct() {
    this.match = false;
    this.getAllVarientProductSub = this.editServ
      .getVariantsById(this.prodId)
      .subscribe({
        next: (n) => {
          if (this.isedit) {
            n = n.filter((x) => x.id == this.variantid);
            let color: Icolor = {
              id: 1,
              code: n[0].code,
              name: n[0].colorName,
            };
            this.listColor.push(color);
            let size: Isize = {
              id: 1,
              size: n[0].size,
            };
            this.listSize.push(size);
            this.ProductVariantList = n;

            console.log(n);
            this.assignValuetoForm();
          } else {
            this.ProductVariantList = n;
          }
        },
        error: (e) => {
          console.log('ERROR when fetch ProductVarien');
          console.log(e);
        },
      });
  }

  assignValuetoForm() {
    this.productVariantForm.controls['price'].setValue(
      this.ProductVariantList[0].price
    );
    this.productVariantForm.controls['disceount'].setValue(
      this.ProductVariantList[0].discount
    );
    this.productVariantForm.controls['quantiy'].setValue(
      this.ProductVariantList[0].quantity
    );
  }
  getColorcode(id: number): string {
    const sizeObj = this.listColor.find((x) => x.id == id);
    return sizeObj ? sizeObj.code : 'not found';
  }

  getSizename(id: number): string {
    const sizeObj = this.listSize.find((x) => x.id == id);
    return sizeObj ? sizeObj.size : 'not found';
  }

  addVariant(e: Event) {
    e.preventDefault();
    if (this.productVariantForm.valid) {
      const vary: IaddVariant = {
        colorId: this.productVariantForm.get('color')?.value,
        unitPrice: this.productVariantForm.get('price')?.value,
        discount: this.productVariantForm.get('disceount')?.value / 100,
        quantity: this.productVariantForm.get('quantiy')?.value,
        sizeId: this.productVariantForm.get('size')?.value,
        productId: this.prodId,
      };

      if (this.isedit) {
        let update :IupdateVariant = {
          unitPrice: vary.unitPrice.toString(),
          discount: vary.discount.toString(),
          quantity: vary.quantity.toString(),
        }

        this.addProductVariantSub = this.editServ.updateVarient(this.variantid,update).subscribe({
          next: (d) => {
            console.log('done');
            this._router.navigate(['/admin/product/detials', this.prodId]);
          },
          error: (e) => {
            console.log('ERROR when update varient');
          },
        })
      } else {
        
        for (let x of this.ProductVariantList) {
          const sizename = this.getSizename(vary.sizeId);
          const colorCode = this.getColorcode(vary.colorId);
          console.log(colorCode);
          console.log('size', vary.sizeId, sizename);
          if (x.size == sizename && x.code == colorCode) {
            console.log('use before');
            this.match = true;
            break;
          }
        }
        if (!this.match) {
          this.addProductVariantSub = this.editServ.addVariant(vary).subscribe({
            next: (d) => {
              console.log('done');
              this._router.navigate(['/admin/product/detials', this.prodId]);
            },
            error: (e) => {
              console.log('ERROR when ADD varient');
            },
          });
        } else {
          console.log('maaaaaaaaaaan');
        }
      }
    } else {
      this.showerroS = true;
    }
  }
}
