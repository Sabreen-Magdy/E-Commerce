import { compileNgModule } from '@angular/compiler';
import { CartService } from './../../../services/cart.service';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth.service';
import { AddCart } from 'src/app/models/icart';
import { IaddFavorite } from 'src/app/models/Ifav';
import { IproductDTo } from 'src/app/models/iproduct-dto';
import { IproductReviws } from 'src/app/models/iproduct-reviws';
import { IproductVarDet } from 'src/app/models/iproduct-var-det';
import { FavoriteService } from 'src/app/services/favorite.service';
import { ProductDetailsService } from 'src/app/services/product-details.service';
import { FormControl, FormGroup ,Validators} from '@angular/forms';
import { ProductIReview, Review } from 'src/app/models/ireview';
import { ProductReviewService } from 'src/app/services/reviews.service';



@Component({
  selector: 'app-product-details-main',
  templateUrl: './product-details-main.component.html',
  styleUrls: ['./product-details-main.component.css']
})
export class ProductDetailsmainComponent implements OnInit {
  commentForm : FormGroup;
  allStars!: NodeListOf<HTMLElement>;
  ratingValue!: HTMLInputElement;
  buttonText:string="أضف للعربة";
  activeStarsCount:any;
  prodVariantList: IproductVarDet[] = [];
  prodDet: IproductDTo = {
    "id": 0,
    "name": "waiting",
    "avgRating": 0,
    "numberReviews": 0,
    "description": "undefine"
  };
  prodDetrev: IproductReviws[] = [];
  customerHasReview:boolean=false;
  isProductInFav : boolean = false;
  waitingFav : boolean = false;
  // sizeIndexMap: { [size: string]: number } = {};
  id: number = 0;
  customerId : number = 0;
  addFavSub : Subscription | undefined;
  addcartSub : Subscription | undefined;
  getFavSub : Subscription | undefined;
  deleteFavsub : Subscription | undefined;
  constructor(private prodDetApi: ProductDetailsService, private Actrouter: ActivatedRoute , private favService : FavoriteService , private authService : AuthService, private CartServi : CartService,private revService:ProductReviewService) {
    this.commentForm = new FormGroup({
      comment : new FormControl (
        "",
        [
          Validators.required,
          Validators.minLength(10),
          Validators.pattern('[\u0600-\u06FF ,]+')
        ]
      ),
    }
    );}
    get mainaddresscontrol(){
      return this.commentForm.get('comment')
    }
  ngOnInit(): void {

    this.customerId = this.authService.id;
    this.id = this.Actrouter.snapshot.params['id'];
    console.log("hiiiiiii" + this.id);
    this.prodDetApi.getAll(this.id).subscribe({
      next: (data) => {
        this.prodVariantList = data.filter(item => item.quantity > 0);
        console.log(this.prodVariantList);
        this.selectedImage = this.prodVariantList[0].coloredimage;
        this.selectedColor = this.prodVariantList[0].colorName;
       this.selectedColorCode = this.prodVariantList[0].code;
        this.selectedSize = this.prodVariantList[0].size ;
        this.selectedvariant = this.prodVariantList[0]
        this.groupedByColor = this.groupByColorCode(this.prodVariantList);
        console.log(this.groupedByColor)
      }
    });
    this.checkFavourite();
    this.prodDetApi.getProd(this.id).subscribe({
      next: (data) => {
        this.prodDet = data;

        console.log(this.prodDet);
      }
    });

    this.prodDetApi.getProdReviews(this.id).subscribe({
      next: (data) => {
        this.prodDetrev = data;
        data.forEach(rev => {
          if(rev.customerId==this.customerId){
            this.customerHasReview=true;
          }
        });
        console.log(this.prodDetrev);
      }
    });

    this.getUniqueColors();
    this.getUniqueCode
// reviewwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww
      this.allStars = document.querySelectorAll('.rating .star') as NodeListOf<HTMLElement>;
      this.ratingValue = document.querySelector('.rating input') as HTMLInputElement;
      this.allStars.forEach((star, idx) => {
        star.addEventListener('click', () => {
          let click = 0;
          this.ratingValue.value = String(idx + 1);

          this.allStars.forEach(i => {
            i.classList.replace('bxs-star', 'bx-star');
            i.classList.remove('active');
          });
          for (let i = 0; i < this.allStars.length; i++) {
            if (i <= idx) {
              this.allStars[i].classList.replace('bx-star', 'bxs-star');
              this.allStars[i].classList.add('active');
            } else {
              (this.allStars[i] as HTMLElement).style.setProperty('--i', String(click));
              click++;
            }
          }
          this.activeStarsCount = document.querySelectorAll('.rating .active').length;
          console.log('Number of active stars:',this.activeStarsCount);
        });

      });


  }

  confirmComment(e:Event){
      if (this.commentForm.valid){
         let productId=this.prodDet.id ;
         let customerId= this.authService.id;
         let rate= this.activeStarsCount;
         let content= this.commentForm.get('comment')?.value;

        console.log(rate,content);
        this.revService.addProductReview(customerId,productId,content,rate).subscribe({
          next: (data) => {
            console.log(data);
            this.commentForm.get('comment')?.setValue("");
            this.prodDetApi.getProdReviews(this.id).subscribe({
              next: (data) => {
                this.prodDetrev = data;
                console.log(this.prodDetrev);
              }
            });
          }
        });;
      }

   }
  // reviewwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww

    // This function extracts unique colors from the prodVariantList
  groupByColorCode(productVariants: IproductVarDet[]): Record<string, IproductVarDet[]> {
    const grouped: Record<string, IproductVarDet[]> = {};

    productVariants.forEach(variant => {
      const colorCode = variant.code;
      if (!grouped[colorCode]) {
        grouped[colorCode] = [];
      }
      grouped[colorCode].push(variant);
    });

    return grouped;
  }
  groupedByColor : Record<string, IproductVarDet[]> ={}

  list: string[] = [
    "https://cdn1.iconfinder.com/data/icons/loading-icon/100/loading_icon-01-512.png"

  ];

  color = [
    {
      name: "الاسود",
      code: "#000000"
    },

  ];
  size = [
    "S"
  ];

  showUpArrow: boolean = false;
  showDownArrow: boolean = true;
  open: boolean = false;
  selectedindex: number = 0;
  selectedImage: string = this.list[0];
  selectedColor: string = this.color[0].name;
  selectedColorCode:string = this.color[0].code;
  selectedvariant:IproductVarDet={code:"",coloredimage:'' , colorName:'',discount:0 , id:0 ,offerPrice:0 ,price:0 ,priceAfter:0 ,quantity:0 ,size:''};
  selectedSize: string = this.size[0];
  quantityNumber: number = 1;
  currentPage: number = 1;
  itemsPerPage: number = 3;
  @ViewChild('smallImgs') smallImgs!: ElementRef;

  scroll(direction: 'up' | 'down'): void {
    const smallImgsElement = this.smallImgs.nativeElement as HTMLElement;
    const scrollAmount = 300; // Adjust this value as needed
    if (direction === 'up') {
      smallImgsElement.scrollTop -= scrollAmount;

    } else {
      smallImgsElement.scrollTop += scrollAmount;
    }
    this.checkArrowsVisibility();
  }

  checkArrowsVisibility(): void {
    const smallImgsElement = this.smallImgs.nativeElement as HTMLElement;
    this.showUpArrow = smallImgsElement.scrollTop > 0;
    this.showDownArrow =
      smallImgsElement.scrollTop + smallImgsElement.clientHeight < smallImgsElement.scrollHeight;
  }

  onScroll(): void {
    this.checkArrowsVisibility();
  }

  showImage(event: any, index: number, variant:IproductVarDet): void {
    if (event.target.tagName === 'IMG') {
      this.selectedImage = event.target.src;
      this.selectedindex = index;
      this.selectedvariant=variant
      this.selectedColorCode = variant.code
      this.selectedColor = variant.colorName;
      this.selectedSize = variant.size ;
      this.quantityNumber = 1; // Reset quantity to 1
    }
  }
  selectColor(variant: IproductVarDet, index: number): void {

    this.selectedColor = variant.colorName;
    this.selectedindex = index;
    this.selectedColorCode = variant.code
    this.selectedvariant=variant
    this.selectedImage = variant.coloredimage;
    this.selectedSize = variant.size;
    this.quantityNumber = 1; // Reset quantity to 1
  }
  selectSize(sizename: string, variant:IproductVarDet): void {

    this.selectedSize = sizename ;
    this.selectedvariant = variant
    // this.selectedindex = index;
    // this.selectedImage = this.prodVariantList[this.selectedindex].coloredimage;
    // this.selectedSize = this.prodVariantList[this.selectedindex].size+index
    // this.selectedColor = this.prodVariantList[this.selectedindex].colorName;
    this.quantityNumber = 1; // Reset quantity to 1
  }
  plus() {
    if (this.quantityNumber <= this.selectedvariant!.quantity) {
      this.quantityNumber++;
      this.CartServi.getNumberOfitemInCart();
    }
  }
  minus() {
    if (this.quantityNumber > 1) {
      this.quantityNumber--;
      this.CartServi.getNumberOfitemInCart();
    }
  }
  toggle() {
    var div = document.getElementById("descptionProductString");
    div?.classList.toggle('active');
    if (this.open == true) {
      this.open = false;
    } else {
      this.open = true;
    }


    console.log(this.open);

  }
  getPaginatedList(): any[] {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    return this.list.slice(startIndex, endIndex);
  }

  goToPage(pageNumber: number): void {
    this.currentPage = pageNumber;
  }

  nextPage(): void {
    if (this.currentPage < this.getTotalPages()) {
      this.currentPage++;
    }
  }
  getStarArray(count: number): any[] {
    return Array(count).fill(0);
  }
  prevPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }

  getTotalPages(): number {
    return Math.ceil(this.list.length / this.itemsPerPage);
  }


  getUniqueColors(): string[] {
    return Array.from(new Set(this.prodVariantList.map(item => item.colorName)));
  }

  getUniqueCode() : string[]{
    return Array.from(new Set(this.prodVariantList.map(item => item.code)));
  }

  // getUniqueColors(): { name: string, code: string }[] {
  //   const uniqueColorNames = Array.from(new Set(this.prodVariantList.map(item => item.colorName)));
  //   return uniqueColorNames.map(colorName => {
  //     const variant = this.prodVariantList.find(item => item.colorName === colorName);
  //     return { name: colorName, code: variant ? variant.code : '' }; // Assuming 'code' is the property for color codes in your variant objects
  //   });
  // }

  pushItemToFavCart( prodId : number ){
    this.waitingFav = true;
    const addFav : IaddFavorite = {
      customerId: this.customerId,
      productId: prodId
  }

   this.addFavSub = this.favService.additemTofav(addFav).subscribe({
    next : (data) => {
      this.waitingFav = false;
      console.log("item Add to Fav Succesfully" + data);
      this.favService.getNumberOfitemInFavCart();
      this.isProductInFav = true;
    },
    error : (e) => {
      console.log("may bt item in fav already");
      console.log("ERROR when add fav to item" + e);
    }
   })
  }

  checkFavourite (){
    this.getFavSub = this.favService.getallFavbycustomr(this.customerId).subscribe({
      next: (data) =>{
            console.log("Product id  " + this.id);
            console.log("customrt id  " + this.customerId);
            console.log(data);
        data.forEach(element => {
          console.log(element.productId);
          if (element.productId == this.id){
            console.log("found product id in fav");
            this.isProductInFav = true;
            console.log(this.isProductInFav);
          }
        });
      }
    })
  }

  deleteFavitem(){
    this.waitingFav = true;
    this.deleteFavsub = this.favService.deletefavitem(this.customerId,this.id).subscribe({
      next : (data) => {
        this.waitingFav = false;
        console.log("succesful delete: " + data);
        this.favService.getNumberOfitemInFavCart();
        this.isProductInFav = false;
      },
      error : (e)=>{
        console.log("ERROR when delete fav item" + e);
      }
    });
   }

  pushItemTocart (){
    console.log(this.selectedvariant.id);
    console.log(this.quantityNumber);

    const addcart : AddCart = {
      productVarientId: this.selectedvariant.id,
      state: 0,
      quantity: this.quantityNumber
    }

    this.addcartSub = this.CartServi.addCartItem(this.customerId,addcart).subscribe({
      next: (done) => {
        console.log("Added Succesful" + done);
        this.buttonText="تم إضافة المنتج"
        this.CartServi.getNumberOfitemInCart();
      },
      error : (e) => {
        this.buttonText="ذلك المنتج متواجد بالفعل في السلة"

        console.log("ERROR when delete" + e);
      }
    })
  }
}
