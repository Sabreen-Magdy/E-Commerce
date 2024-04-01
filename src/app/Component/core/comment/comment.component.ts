import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { IproductDTo } from 'src/app/models/iproduct-dto';
import { IproductReviws } from 'src/app/models/iproduct-reviws';
import { IproductVarDet } from 'src/app/models/iproduct-var-det';
import { FavoriteService } from 'src/app/services/favorite.service';
import { ProductDetailsService } from 'src/app/services/product-details.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent {
  commentForm: FormGroup;
  allStars!: NodeListOf<HTMLElement>;
  ratingValue!: HTMLInputElement;
  buttonText: string = "أضف للعربة";
  subText: string = "تأكيد"
  activeStarsCount: any;
  p : number = 1;
  prodVariantList: IproductVarDet[] = [];
  prodDet: IproductDTo = {
    "id": 0,
    "name": "waiting",
    "avgRating": 0,
    "numberReviews": 0,
    "description": "undefine"
  };
  prodDetrev: IproductReviws[] = [];
  customerHasReview: boolean = false;
  isProductInFav: boolean = false;
  waitingFav: boolean = false;
  // sizeIndexMap: { [size: string]: number } = {};
  id: number = 0;
  customerId: number = 0;
  addFavSub: Subscription | undefined;
  addcartSub: Subscription | undefined;
  getFavSub: Subscription | undefined;
  deleteFavsub: Subscription | undefined;

  getProductDetailsRev(){
    this.prodDetApi.getProdReviews(this.id).subscribe({
      next: (data: any[]) => {
        this.prodDetrev = data;
        data.forEach(rev => {
          if (this.customerId == rev.customerId) {
            this.customerHasReview = true;
            this.subText = "لقد أضفت تعليقا من قبل";
            (document.querySelector('.btn-group .submit') as HTMLInputElement).classList.add('disabled');

          }
        });
        console.log(this.prodDetrev);
      }
    });
    }
    getProductDetails(){

      this.prodDetApi.getProd(this.id).subscribe({
        next: (data: IproductDTo) => {
          this.prodDet = data;
  
          console.log(this.prodDet);
        }
      });
    }
  constructor(private prodDetApi: ProductDetailsService, private Actrouter: ActivatedRoute, private favService: FavoriteService, private authService: AuthService, private CartServi: CartService, private revService: ProductReviewService) {
    this.commentForm = new FormGroup({
      comment: new FormControl(
        ""
        ,
        [
          Validators.required,
          Validators.pattern('[\u0600-\u06FF ,]+')
        ]
      ),
    }
    );
  }

}
