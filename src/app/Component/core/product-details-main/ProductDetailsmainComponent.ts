import { compileNgModule } from '@angular/compiler';
import { CartService } from './../../../services/cart.service';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription, map } from 'rxjs';
import { AuthService } from 'src/app/auth.service';
import { AddCart, CartDto, CartItemDto, Uppdatecart } from 'src/app/models/icart';
import { favitem, IaddFavorite } from 'src/app/models/Ifav';
import { IproductDTo } from 'src/app/models/iproduct-dto';
import { IproductReviws } from 'src/app/models/iproduct-reviws';
import { IproductByGategory, IproductVarDet } from 'src/app/models/iproduct-var-det';
import { FavoriteService } from 'src/app/services/favorite.service';
import { ProductDetailsService } from 'src/app/services/product-details.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ProductIReview, Review } from 'src/app/models/ireview';
import { ProductReviewService } from 'src/app/services/reviews.service';
import { Iproduct } from 'src/app/models/iproduct';
import Swal from 'sweetalert2';
// import 'swiper/swiper-bundle.min.css';
// import Swiper from 'swiper';

@Component({
  selector: 'app-product-details-main',
  templateUrl: './product-details-main.component.html',
  styleUrls: ['./product-details-main.component.css']
})
export class ProductDetailsmainComponent implements OnInit {
  commentForm: FormGroup;
  allStars!: NodeListOf<HTMLElement>;
  ratingValue!: HTMLInputElement;
  buttonText: string = "أضف للعربة";
  subText: string = "تأكيد";
  waitingDoneSendReview : boolean = false;
  activeStarsCount: any;
  p: number = 1;
  pp:number = 1;
  prodVariantList: IproductVarDet[] = [];
  prodVariantListOriginal: IproductVarDet[] = [];
  FavList : favitem[]=[];
  isFiv : boolean = false;

  prodDet: IproductDTo = {
    "id": 0,
    "name": "waiting",
    "avgRating": 0,
    "numberReviews": 0,
    "description": "undefine"
  };
  prodDetrev: IproductReviws[] = [];
  isProductInFav: boolean = false;
  waitingFav: boolean = false;
  // sizeIndexMap: { [size: string]: number } = {};
  id: number = 0;
  customerId: number = 0;
  customerCanAddRev: boolean = false;
  addFavSub: Subscription | undefined;
  addcartSub: Subscription | undefined;
  getFavSub: Subscription | undefined;
  deleteFavsub: Subscription | undefined;
  cart: CartDto = {
    totalPrice: 0,
    totalQuantity: 0,
    items: [],
  };
  cartitems:CartItemDto[]=[]
  plusAppearance: boolean = true;
  getProductDetailsRev() {
    this.prodDetApi.getProdReviews(this.id).subscribe({
      next: (data) => {

        this.prodDetrev = data;
        data.forEach(rev => {
        });
        console.log(this.prodDetrev);
      }
    });
  }
  getProductDetails() {

    this.prodDetApi.getProd(this.id).subscribe({
      next: (data) => {
        data.avgRating = Math.floor(data.avgRating)
        this.prodDet = data;

        console.log(this.prodDet);
      }
    });
  }
  proctCategories: { id: number, name: string }[] = []
  getProductcategories() {

    this.prodDetApi.getProdCategories(this.id).subscribe({
      next: (data) => {
        //data.avgRating = Math.floor(data.avgRating)
        this.proctCategories = data;
        console.log(this.proctCategories);
        this.getProductsBygategories(this.proctCategories[0].name);
        console.log("products of ccccaaaaaat");
        console.log(this.productsByCat);

      }
    });
  }
  productsByCat: IproductByGategory[] = []
  getProductsBygategories(categoryName: string) {
    this.prodDetApi.getProductsByCategories(categoryName).subscribe({
      next: (data) => {

        //data.avgRating = Math.floor(data.avgRating)
        this.productsByCat = data.filter(p => p.id != this.id);
        console.log(this.productsByCat);
      }
    });
  }

  constructor(private prodDetApi: ProductDetailsService, private Actrouter: ActivatedRoute, private favService: FavoriteService, private authService: AuthService, private CartServi: CartService, private revService: ProductReviewService, private router: Router) {
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
  get commentcontrol() {
    return this.commentForm.get('comment')
  }
  noitem:boolean=false
  getcartbyId(productvar :number[]) {
    console.log('dkdkd');
    console.log(this.customerId);
    this.CartServi.getCartBycstId(
      this.customerId
    ).subscribe({
      next: (data) => {
        let filterdata = data.items.filter((item) => item.state == 0);
        let totalPriceS: number = 0;
        // this.cart.items = this.cart.items.filter((item)=>item.state==0)
        for (var item of filterdata) {
          item.unitPrice = item.unitPrice - (item.unitPrice * item.discount)
          totalPriceS += item.unitPrice * item.quantity;
        }
        this.cart = data;
        this.cart.items = filterdata;
        this.cart.totalPrice = totalPriceS;
        this.cartitems = []
        for (let index = 0; index < this.cart.items.length; index++) {
          for (let index2 = 0; index2 < productvar.length; index2++) {
            if(this.cart.items[index].productVarientId == productvar[index2]){
              this.cartitems.push(this.cart.items[index])
            }
          }
        }
        console.log('shared cart items', this.cartitems);

        for (let index = 0; index < this.prodVariantList.length; index++) {
          for (let index2 = 0; index2 < this.cartitems.length; index2++) {
            if (this.cartitems[index2].productVarientId == this.prodVariantList[index].id) { // cartitems = {{2,3},{4,2}} , prodvar = {{1,3},{2,4}, {3,3},{4,5}}
              this.prodVariantList[index].quantity -= this.cartitems[index2].quantity
              //console.log('inside the iiiiiffffff')
              break;
            }
          }
         
        }
        this.groupedByColor = this.groupByColorCode(this.prodVariantList);
        // this.plusAppearance = this.prodVariantList[0].quantity > 1
        console.log('product var list after edit ',this.prodVariantList)


        if (filterdata.length == 0) {
          this.noitem = true;
        }
        if(this.selectedvariant.quantity == 0){
          document.getElementById('addtocart')?.setAttribute('disabled', 'true')
        }else{
          document.getElementById('addtocart')?.removeAttribute('disabled')
        }
       // this.waitUpdatNumber = false;
      },
      error: (e) => {
        this.noitem = true;
        console.log('ERROR when fetch Data of CartItem' + e);
      },
    });
  }
  ngOnInit(): void {
    this.customerId = this.authService.id;
    this.id = this.Actrouter.snapshot.params['id'];
    console.log("hiiiiiii" + this.id);
    this.revService.isCustomerCanAddRev(this.customerId, this.id).subscribe({
      next: (data) => {
        this.customerCanAddRev = data;
        console.log(this.customerCanAddRev)
        console.log("Customer can Review??????????????", data);
      }

    })
    this.prodDetApi.getAll(this.id).subscribe({
      next: (data) => {
        this.prodVariantList = JSON.parse(JSON.stringify(data.filter(p=>p.quantity>0)));
        this.prodVariantListOriginal = JSON.parse(JSON.stringify(data.filter(p=>p.quantity>0)));
        console.log("prodVariantListOriginal on init",this.prodVariantListOriginal)
        // for (let index = 0; index < this.prodVariantList.length; index++) {
        //   if(this.prodVariantList[index].quantity <1){
        //     this.outofStok.push(false)
        //   }else{
        //     this.outofStok.push(true)
        //   }

        // }
        console.log(this.prodVariantList);
        this.selectedImage = this.prodVariantList[0].coloredimage;
        this.selectedColor = this.prodVariantList[0].colorName;
        this.selectedColorCode = this.prodVariantList[0].code;
        this.selectedSize = this.prodVariantList[0].size;
        this.plusAppearance = this.prodVariantList[0].quantity > 1
        this.getcartbyId(this.prodVariantList.map(p=>p.id));
        this.selectedvariant = this.prodVariantList[0]
       
        this.groupedByColor = this.groupByColorCode(this.prodVariantList);
        console.log(this.groupedByColor)
        console.log("selected variant to disable quantity" , this.selectedvariant.quantity)

        if(this.selectedvariant.quantity == 0){
          document.getElementById('addtocart')?.setAttribute('disabled', 'true')
        }else{
          document.getElementById('addtocart')?.removeAttribute('disabled')
        }
      }
    });
    this.checkFavourite();
    this.getProductDetails()
    this.getProductDetailsRev()
    this.getUniqueColors();
    this.getProductcategories()
    // this.getUniqueCode()

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
        console.log('Number of active stars:', this.activeStarsCount);
      });

    });


  }
  // outofStok:boolean[] = []
  clearForm() {
    this.commentForm.get('comment')?.setValue("");
    (document.querySelectorAll('.rating input i') as NodeListOf<HTMLElement>).forEach(i => {
      i.classList.remove('active');
      console.log(i)
    });
  }



  showerror: boolean = false;
  numOfStar:boolean=true;
  confirmComment(e: Event) {
    if (this.commentForm.valid &&this.activeStarsCount>0) {
      this.waitingDoneSendReview = true;
      this.subText = "";
      let productId = this.prodDet.id;
      let customerId = this.authService.id;
      let rate = this.activeStarsCount;
      let content = this.commentForm.get('comment')?.value;
      console.log(rate, content);
      this.revService.addProductReview(customerId, productId, content, rate).subscribe({
        next: (data) => {
          // this.clearForm()
          // this.commentForm.get('comment')?.setValue("");
          this.getProductDetails()
          this.prodDetApi.getProdReviews(this.id).subscribe({
            next: (data) => {
              this.prodDetrev = data;
              this.waitingDoneSendReview = false;
              this.subText="أضف تعليقًا أخر"
              // location.reload()
              console.log(this.prodDetrev);
            }
          });
        }
      });;
    }else if(this.activeStarsCount<1){
      this.numOfStar=false;
    }
    else {
      this.showerror = true;
      console.log("ادخل تقييم النجوم")
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
  groupedByColor: Record<string, IproductVarDet[]> = {}

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
  selectedColorCode: string = this.color[0].code;
  selectedvariant: IproductVarDet = { code: "", coloredimage: '', colorName: '', discount: 0, id: 0, offerPrice: 0, price: 0, priceAfter: 0, quantity: 0, size: '' };
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

  showImage(event: any, index: number, variant: IproductVarDet): void {
    this.selectedImage = variant.coloredimage;
    this.selectedindex = index;
    this.selectedvariant = variant;
    this.selectedColorCode = variant.code;
    this.selectedColor = variant.colorName;
    this.selectedSize = variant.size;
    this.quantityNumber = 1; // Reset quantity to 1
    this.plusAppearance = true
    this.buttonText = " اضف للعربة"
    if(this.selectedvariant.quantity == 0){
      document.getElementById('addtocart')?.setAttribute('disabled', 'true')
    }else{
      document.getElementById('addtocart')?.removeAttribute('disabled')
    }
  }

  selectColor(variant: IproductVarDet, index: number): void {

    this.selectedColor = variant.colorName;
    this.selectedindex = index;
    this.selectedColorCode = variant.code
    this.selectedvariant = variant
    this.selectedImage = variant.coloredimage;
    this.selectedSize = variant.size;
    this.quantityNumber = 1; // Reset quantity to 1
    this.plusAppearance = true
    this.buttonText = " اضف للعربة"
    if(this.selectedvariant.quantity == 0){
      document.getElementById('addtocart')?.setAttribute('disabled', 'true')
    }else{
      document.getElementById('addtocart')?.removeAttribute('disabled')
    }
  }
  selectSize(sizename: string, variant: IproductVarDet): void {

    this.selectedSize = sizename;
    this.selectedvariant = variant
    // this.selectedindex = index;
    // this.selectedImage = this.prodVariantList[this.selectedindex].coloredimage;
    // this.selectedSize = this.prodVariantList[this.selectedindex].size+index
    // this.selectedColor = this.prodVariantList[this.selectedindex].colorName;
    this.quantityNumber = 1; // Reset quantity to 1
    this.plusAppearance = true

    this.buttonText = " اضف للعربة"
    if(this.selectedvariant.quantity == 0){
      document.getElementById('addtocart')?.setAttribute('disabled', 'true')
    }else{
      document.getElementById('addtocart')?.removeAttribute('disabled')
    }
  }
  plus() {
    if (this.quantityNumber < this.selectedvariant!.quantity) {
      this.quantityNumber++;
      this.CartServi.getNumberOfitemInCart();
    } else {
      this.plusAppearance = false
    }
  }
  minus() {
    if (this.quantityNumber > 1) {
      this.quantityNumber--;
      this.CartServi.getNumberOfitemInCart();
      this.plusAppearance = true
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
  
  getStarArray(count: number): any[] {
    return Array(count).fill(0);
  }
 



  getUniqueColors(): string[] {
    return Array.from(new Set(this.prodVariantList.map(item => item.colorName)));
  }

  getUniqueCode(): string[] {
    return Array.from(new Set(this.prodVariantList.map(item => item.code)));
  }

  // getUniqueColors(): { name: string, code: string }[] {
  //   const uniqueColorNames = Array.from(new Set(this.prodVariantList.map(item => item.colorName)));
  //   return uniqueColorNames.map(colorName => {
  //     const variant = this.prodVariantList.find(item => item.colorName === colorName);
  //     return { name: colorName, code: variant ? variant.code : '' }; // Assuming 'code' is the property for color codes in your variant objects
  //   });
  // }

  pushItemToFavCart(prodId: number) {
    this.authService.userData.subscribe({
      next:()=>{
        if(this.authService.userData.getValue()!=null){
    this.waitingFav = true;
    const addFav: IaddFavorite = {
      customerId: this.customerId,
      productId: prodId
    }

    this.addFavSub = this.favService.additemTofav(addFav).subscribe({
      next: (data) => {
        this.waitingFav = false;
        console.log("item Add to Fav Succesfully" + data);
        this.favService.getNumberOfitemInFavCart();
        this.isProductInFav = true;
        
      },
      error: (e) => {
        console.log("may bt item in fav already");
        console.log("ERROR when add fav to item" + e);
      }
    })
  }else{
    Swal.fire({
   title: 'سجل دخول حتى تتمكن من رحلة التسوق معنا!',
   confirmButtonColor: '#198754', // Change this to the color you prefer
  });
  }
  }
  });

  }

  pushItemToFavCart2(prodId: number) {
    this.authService.userData.subscribe({
      next:()=>{
        if(this.authService.userData.getValue()!=null){
  
    const addFav: IaddFavorite = {
      customerId: this.customerId,
      productId: prodId
    }

    this.addFavSub = this.favService.additemTofav(addFav).subscribe({
      next: (data) => {
        Swal.fire({
          title: 'تم إضافة المنتج إلى قائمة أمنياتي',
          confirmButtonColor: '#198754', // Change this to the color you prefer
        });
        console.log("item Add to Fav Succesfully" + data);
        this.favService.getNumberOfitemInFavCart();
        this.checkFavourite();
      },
      error: (e) => {
        console.log("may bt item in fav already");
        console.log("ERROR when add fav to item" + e);
      }
    })
  }else{
    Swal.fire({
   title: 'سجل دخول حتى تتمكن من رحلة التسوق معنا!',
   confirmButtonColor: '#198754', // Change this to the color you prefer
  });
  }
  }
  });

  }
  checkFavourite() {
    this.getFavSub = this.favService.getallFavbycustomr(this.customerId).subscribe({
      next: (data) => {
        this.FavList = data;
        console.log("Product id  " + this.id);
        console.log("customrt id  " + this.customerId);
        console.log(data);
        data.forEach(element => {
          console.log(element.productId);
          if (element.productId == this.id) {
            console.log("found product id in fav");
            this.isProductInFav = true;
            console.log(this.isProductInFav);
          }
        });
      }
    })
  }

  deleteFavitem(id : number) {
    this.waitingFav = true;
    this.deleteFavsub = this.favService.deletefavitem(this.customerId, id).subscribe({
      next: (data) => {
        this.waitingFav = false;
        console.log("succesful delete: " + data);
        this.favService.getNumberOfitemInFavCart();
        this.isProductInFav = false;
      },
      error: (e) => {
        console.log("ERROR when delete fav item" + e);
      }
    });
  }

  deleteFavitem2(id : number) {
  
    this.deleteFavsub = this.favService.deletefavitem(this.customerId, id).subscribe({
      next: (data) => {
        Swal.fire({
          title: 'تم ازالة المنتج من قائمة أمنياتك',
          confirmButtonColor: '#198754', // Change this to the color you prefer
        });
        console.log("succesful delete: " + data);
        this.checkFavourite();
        this.favService.getNumberOfitemInFavCart();
        
      },
      error: (e) => {
        console.log("ERROR when delete fav item" + e);
      }
    });
  }
  increasecartItem(productId: number, itemquantity: number) {

    const updatecart: Uppdatecart = {
      state: 0,
      quantity: itemquantity + this.quantityNumber,
    };
    console.log(this.customerId);
    console.log(productId);
    console.log(updatecart);
    this.CartServi.updateCartItem(
      this.customerId,
      productId,
      updatecart
    ).subscribe({
      next: (data) => {
        console.log('increased quantity');
        this.cartitems =[]

        // this.getcartbyId(this.prodVariantList.map(p=>p.id));
        const indexofvarupdated = this.prodVariantList.indexOf(this.selectedvariant)
        // console.log("indexofvarupdated",indexofvarupdated)
        // this.prodVariantList[indexofvarupdated].quantity-=this.quantityNumber
        //this.prodVariantList=this.prodVariantListOriginal
        // this.prodVariantList = [...this.prodVariantListOriginal];
        this.prodVariantList = JSON.parse(JSON.stringify(this.prodVariantListOriginal));
        console.log("prodVariantList",this.prodVariantList)
        console.log("prodVariantListOriginal",this.prodVariantListOriginal)
        this.getcartbyId(this.prodVariantList.map(p=>p.id))
        this.selectedvariant = this.prodVariantList[indexofvarupdated]

        // this.groupedByColor = this.groupByColorCode(this.prodVariantList);
        this.quantityNumber=1

      },

      // error: (e) => {
      //   console.log('Error when Update' + e);
      //   this.isMaxThanAvailable = true;
      //   this.waitUpdatNumber = false;
      //   this.getcartbyId();
      // },
    });
  }

  pushItemTocart() {
    this.authService.userData.subscribe({
      next:()=>{
        if(this.authService.userData.getValue()!=null){
    console.log(this.selectedvariant.id);
    console.log(this.quantityNumber);

    const addcart: AddCart = {
      productVarientId: this.selectedvariant.id,
      state: 0,
      quantity: this.quantityNumber
    }
    var item :CartItemDto
    for (let index = 0; index < this.cartitems.length; index++) {
      // const element = array[index];
      if(this.cartitems[index].productVarientId==this.selectedvariant.id){
        item = this.cartitems[index]
        console.log("item cart that will updated ",item)
        break;
      }
    }

    this.addcartSub = this.CartServi.addCartItem(this.customerId, addcart).subscribe({
      next: (done) => {
        console.log("Added Succesful" + done);
        this.buttonText = "تم إضافة المنتج"
        this.CartServi.getNumberOfitemInCart();
        this.cartitems =[]
        const indexofvarupdated = this.prodVariantList.indexOf(this.selectedvariant)
        // console.log("indexofvarupdated",indexofvarupdated)

        // this.prodVariantList[indexofvarupdated].quantity-=this.quantityNumber
        // this.prodVariantList=  [...this.prodVariantListOriginal]
        this.prodVariantList = JSON.parse(JSON.stringify(this.prodVariantListOriginal));
        this.getcartbyId(this.prodVariantList.map(p=>p.id))
        this.selectedvariant = this.prodVariantList[indexofvarupdated]
        // this.groupedByColor = this.groupByColorCode(this.prodVariantList);
        this.quantityNumber=1
        if(this.selectedvariant.quantity == 0){
          document.getElementById('addtocart')?.setAttribute('disabled', 'true')
        }else{
          document.getElementById('addtocart')?.removeAttribute('disabled')
        }
        // this.getcartbyId(this.prodVariantList.map(p=>p.id))
      },
      error: (e) => {
        this.buttonText = "اضفت المزيد للعربة"
        this.increasecartItem(this.selectedvariant.id ,item.quantity)
       // console.log("ERROR when delete" + e);

       if(this.selectedvariant.quantity == 0){
        document.getElementById('addtocart')?.setAttribute('disabled', 'true')
      }else{
        document.getElementById('addtocart')?.removeAttribute('disabled')
      }
      }
    })
  }else{
    Swal.fire({
   title: 'سجل دخول حتى تتمكن من رحلة التسوق معنا!',
   confirmButtonColor: '#198754', // Change this to the color you prefer
  });
  }
  }
  });
  }



    navigateToAnotherId(id: number) {
    // this.router.navigate(['/store/productDetials',id])
    location.replace('/store/productDetials/' + id)
     }

  // @ViewChild('slider', { static: true }) slider!: ElementRef;

  // slideRight() {
  //   this.slider.nativeElement.scrollLeft += 100; // Adjust the number based on your requirement
  // }

  // slideLeft() {
  //   this.slider.nativeElement.scrollLeft -= 100;
  //    // Adjust the number based on your requirement
  // }

  hoverfun(id: number) {
    console.log('hiiiiiii', id);
    console.log(this.FavList);
    for (let iten of this.FavList) {
      if (iten.productId == id) {
        this.isFiv = true;
        console.log(true);
      }
    }
  }
  unhoverfun(id: number) {
    console.log('bye', id);
    this.isFiv = false;
  }

}
