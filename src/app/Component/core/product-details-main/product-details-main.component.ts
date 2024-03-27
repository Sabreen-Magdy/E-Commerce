import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProductVariant } from 'src/app/models/i-product-variant';
import { IproductDTo } from 'src/app/models/iproduct-dto';
import { IproductReviws } from 'src/app/models/iproduct-reviws';
import { IproductVarDet } from 'src/app/models/iproduct-var-det';
import { ProductDetailsService } from 'src/app/services/product-details.service';

@Component({
  selector: 'app-product-details-main',
  templateUrl: './product-details-main.component.html',
  styleUrls: ['./product-details-main.component.css']
})
export class ProductDetailsmainComponent implements OnInit {

  constructor(private prodDetApi: ProductDetailsService , private Actrouter:ActivatedRoute) { }
  prodVariantList: IproductVarDet[] = [];
  prodDet: IproductDTo = {
    "id": 0,
    "name": "no name",
    "avgRating": 0,
    "numberReviews": 0,
    "description": "undefine"
  };

  prodDetrev: IproductReviws[] = []
  // sizeIndexMap: { [size: string]: number } = {};
  id : number = 0
  ngOnInit(): void {
    // this.router.paramMap.subscribe(params => {
    //   this.id = params.get('id');
    //   console.log('ID:', id); // Use the ID as needed
    // });
    this.id=this.Actrouter.snapshot.params['id']
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


  }

  list: string[] = [
    "https://media.istockphoto.com/id/955641488/photo/clothes-shop-costume-dress-fashion-store-style-concept.jpg?s=612x612&w=0&k=20&c=ZouECh5-XOCuBzvKBQfxgyw0RIGEUg9u5F0sJiZV86s=",
    // "https://st3.depositphotos.com/9747634/32010/i/450/depositphotos_320104748-stock-photo-hangers-with-different-clothes-in.jpg",
    // "https://media.istockphoto.com/id/1257563298/photo/fashion-clothes-on-a-rack-in-a-light-background-indoors-place-for-text.webp?b=1&s=612x612&w=0&k=20&c=2pLpczTxtUjys6Y33OKehWyqy8g98FlyCbJuUZVUv5k=",
    // "https://media.istockphoto.com/id/533833660/photo/clothing-on-hanger-at-the-modern-shop-boutique.webp?b=1&s=612x612&w=0&k=20&c=VVcA-de6aZvP3H5MfOF1aXn19WTXOV-eS6AnMOjUrvI=",
    // "https://st.depositphotos.com/2209782/2833/i/450/depositphotos_28336025-stock-photo-clothes-on-a-rack.jpg",
    // "https://www.shutterstock.com/image-photo/vintage-red-shoes-on-white-260nw-92008067.jpg",
    // "https://i.pinimg.com/736x/c9/0d/91/c90d91426ae3384073474a42ab38f695.jpg"
  ];

  color = [
    {
      name: "الاسود",
      code: "#000000"
    },
    // {
    //   name: "الابيض",
    //   code: "#FFFFFF"
    // },
    // {
    //   name: "زيتون",
    //   code: "#808000"
    // },
    // {
    //   name: "تركواز",
    //   code: "#008080"
    // },
    // {
    //   name: "أرجواني",
    //   code: "#800080"
    // },
    // {
    //   name: "الأزرق الداكن",
    //   code: "#000080"
    // },
  ];
  size = [
    "S"
    // ,"L","XL","M"
  ]

  showUpArrow: boolean = false;
  showDownArrow: boolean = true;
  open: boolean = false;
  selectedindex: number = 0;
  selectedImage: string = this.list[0]
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
      this.selectedindex = index
      this.selectedColor = this.prodVariantList[this.selectedindex].colorName
      this.selectedSize = this.prodVariantList[this.selectedindex].size + index
      this.quantityNumber = 1; // Reset quantity to 1
    }
  }
  selectColor(colorName: string, index: number): void {

    this.selectedColor = colorName;
    this.selectedindex = index
    this.selectedImage =  this.prodVariantList[this.selectedindex].coloredimage
    this.selectedSize = this.prodVariantList[this.selectedindex].size + index
    this.quantityNumber = 1; // Reset quantity to 1
  }
  selectSize(sizename: string, index: number): void {

    this.selectedSize = sizename + index;
    this.selectedindex = index
    this.selectedImage =  this.prodVariantList[this.selectedindex].coloredimage
    // this.selectedSize = this.prodVariantList[this.selectedindex].size+index
    this.selectedColor = this.prodVariantList[this.selectedindex].colorName
    this.quantityNumber = 1; // Reset quantity to 1
  }
  plus() {
    if (this.quantityNumber <= this.prodVariantList[this.selectedindex].quantity) {
      this.quantityNumber++;
    }
  }
  minus() {
    if (this.quantityNumber > 1) {
      this.quantityNumber--;
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
}
