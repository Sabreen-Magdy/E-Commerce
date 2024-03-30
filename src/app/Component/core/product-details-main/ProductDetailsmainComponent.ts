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



@Component({
  selector: 'app-product-details-main',
  templateUrl: './product-details-main.component.html',
  styleUrls: ['./product-details-main.component.css']
})
export class ProductDetailsmainComponent implements OnInit {
  allStars!: NodeListOf<HTMLElement>;
  ratingValue!: HTMLInputElement;

  constructor(private prodDetApi: ProductDetailsService, private Actrouter: ActivatedRoute , private favService : FavoriteService , private authService : AuthService, private CartServi : CartService) { }
  buttonText:string="أضف للعربة"
  prodVariantList: IproductVarDet[] = [];
  prodDet: IproductDTo = {
    "id": 0,
    "name": "waiting",
    "avgRating": 0,
    "numberReviews": 0,
    "description": "undefine"
  };

  prodDetrev: IproductReviws[] = [];
  // sizeIndexMap: { [size: string]: number } = {};
  id: number = 0;
  customerId : number = 0;

  addFavSub : Subscription | undefined;
  addcartSub : Subscription | undefined;

  ngOnInit(): void {
    // this.router.paramMap.subscribe(params => {
    //   this.id = params.get('id');
    //   console.log('ID:', id); // Use the ID as needed
    // });
    this.customerId = this.authService.id;
    this.id = this.Actrouter.snapshot.params['id'];
    console.log("hiiiiiii" + this.id);
    this.prodDetApi.getAll(this.id).subscribe({
      next: (data) => {
        this.prodVariantList = data.filter(item => item.quantity > 0);
        console.log(this.prodVariantList);
        this.selectedImage = this.prodVariantList[0].coloredimage;
        this.selectedColor = this.prodVariantList[0].colorName;
        this.selectedSize = this.prodVariantList[0].size + 0;
      }
    });
    this.prodDetApi.getProd(this.id).subscribe({
      next: (data) => {
        this.prodDet = data;
        console.log(this.prodDet);
      }
    });

    this.prodDetApi.getProdReviews(this.id).subscribe({
      next: (data) => {
        this.prodDetrev = data;
        console.log(this.prodDetrev);
      }
    });

    this.getUniqueColors();
    this.getUniqueCode
    // This function extracts unique colors from the prodVariantList
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
        });
      });


  }












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

  showImage(event: any, index: number): void {
    if (event.target.tagName === 'IMG') {
      this.selectedImage = event.target.src;
      this.selectedindex = index;
      this.selectedColor = this.prodVariantList[this.selectedindex].colorName;
      this.selectedSize = this.prodVariantList[this.selectedindex].size + index;
      this.quantityNumber = 1; // Reset quantity to 1
    }
  }
  selectColor(colorName: string, index: number): void {

    this.selectedColor = colorName;
    this.selectedindex = index;
    this.selectedImage = this.prodVariantList[this.selectedindex].coloredimage;
    this.selectedSize = this.prodVariantList[this.selectedindex].size + index;
    this.quantityNumber = 1; // Reset quantity to 1
  }
  selectSize(sizename: string, index: number): void {

    this.selectedSize = sizename + index;
    this.selectedindex = index;
    this.selectedImage = this.prodVariantList[this.selectedindex].coloredimage;
    // this.selectedSize = this.prodVariantList[this.selectedindex].size+index
    this.selectedColor = this.prodVariantList[this.selectedindex].colorName;
    this.quantityNumber = 1; // Reset quantity to 1
  }
  plus() {
    if (this.quantityNumber <= this.prodVariantList[this.selectedindex].quantity) {
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
    const addFav : IaddFavorite = {
      customerId: this.customerId,
      productId: prodId
    }

   this.addFavSub = this.favService.additemTofav(addFav).subscribe({
    next : (data) => {
      console.log("item Add to Fav Succesfully" + data);
      this.favService.getNumberOfitemInFavCart();
    },
    error : (e) => {
      console.log("may bt item in fav already");
      console.log("ERROR when add fav to item" + e);
    }
   })
  }

  pushItemTocart (){
    this.buttonText="تم إضافة المنتج"
    console.log(this.prodVariantList[this.selectedindex].id);
    console.log(this.quantityNumber);

    const addcart : AddCart = {
      productVarientId: this.prodVariantList[this.selectedindex].id,
      state: 0,
      quantity: this.quantityNumber
    }

    this.addcartSub = this.CartServi.addCartItem(this.customerId,addcart).subscribe({
      next: (done) => {
        console.log("Added Succesful" + done);
        this.CartServi.getNumberOfitemInCart();
      },
      error : (e) => {
        console.log("ERROR when delete" + e);
      }
    })
  }
}
