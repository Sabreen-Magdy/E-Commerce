import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { IaddColoredImage, IcoloredImage } from 'src/app/models/edit-product';
import { Icolor } from 'src/app/models/icolor';
import { ColorServiceService } from 'src/app/services/color-service.service';
import { EditProductService } from 'src/app/services/edit-product.service';

@Component({
  selector: 'app-color-form',
  templateUrl: './color-form.component.html',
  styleUrls: ['./color-form.component.css'],
})
export class ColorFormComponent implements OnInit {
  productId: number = 1;
  colorList: Icolor[] = [];
  coloredProductList: IcoloredImage[] = [];
  showerroC: boolean = false;
  nowuploadImage: string = '';
  selectedimgUrl: string = '';

  constructor(
    private editServ: EditProductService,
    private colorserv: ColorServiceService,
    private actRoute: ActivatedRoute,
    private _router :Router
  ) {}
  ngOnInit() {
    this.productId = this.actRoute.snapshot.params['id'];
    this.getColoerproduct();
  }

  picForm: FormGroup = new FormGroup({
    colorId: new FormControl('', Validators.required),
    image: new FormControl(null, Validators.required),
  });

  get colorPicFormcontrol() {
    return this.picForm.get('colorId');
  }

  get imagePicFormcontrol() {
    return this.picForm.get('image');
  }

  getAllcolorSub: Subscription | undefined;
  getColoredProduct: Subscription | undefined;
  addColoredImages: Subscription | undefined;

  getColoerproduct() {
    this.getAllcolorSub = this.editServ
      .getProductImages(this.productId)
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
        for (let i = data.length - 1; i >= 0; i--) {
          for (let x of this.coloredProductList) {
            if (data[i].code === x.colorCode) {
              data.splice(i, 1);
              break;
            }
          }
        }

        this.colorList = data
      },
    });
  }


  onFileSelected(event: any) {
    const inputElement = event.target;
    if (inputElement && inputElement.files && inputElement.files.length > 0) {
      const file = inputElement.files[0];
      this.picForm.patchValue({ image: file });
      const imageControl = this.picForm.get('image');
      if (imageControl) {
        imageControl.updateValueAndValidity();
      }
      const reader = new FileReader();
      console.log(reader);
      reader.onload = () => {
        if (typeof reader.result === 'string') {
          this.selectedimgUrl = reader.result;
          console.log('selectedImag', this.selectedimgUrl);
        }
      };
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

  addPhoto(e: Event) {
    e.preventDefault();
    if (this.picForm.valid) {
      const imageColor2: IaddColoredImage = {
        productId: this.productId,
        colorId: this.picForm.get('colorId')?.value,
        image: this.nowuploadImage,
      };
      console.log(this.nowuploadImage);
      console.log(imageColor2);
      this.editServ.addProductImages(imageColor2).subscribe({
        next: (d) => {
          console.log("doneeeeeeeeee");
          this._router.navigate(['/admin/product/detials',this.productId]);
          
        }
    });
    } else {
      this.showerroC = true;
    }
  }
}
