import { Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent {
  list: string[] = [
    "https://media.istockphoto.com/id/955641488/photo/clothes-shop-costume-dress-fashion-store-style-concept.jpg?s=612x612&w=0&k=20&c=ZouECh5-XOCuBzvKBQfxgyw0RIGEUg9u5F0sJiZV86s=",
    "https://st3.depositphotos.com/9747634/32010/i/450/depositphotos_320104748-stock-photo-hangers-with-different-clothes-in.jpg",
    "https://media.istockphoto.com/id/1257563298/photo/fashion-clothes-on-a-rack-in-a-light-background-indoors-place-for-text.webp?b=1&s=612x612&w=0&k=20&c=2pLpczTxtUjys6Y33OKehWyqy8g98FlyCbJuUZVUv5k=",
    "https://media.istockphoto.com/id/533833660/photo/clothing-on-hanger-at-the-modern-shop-boutique.webp?b=1&s=612x612&w=0&k=20&c=VVcA-de6aZvP3H5MfOF1aXn19WTXOV-eS6AnMOjUrvI=",
    "https://st.depositphotos.com/2209782/2833/i/450/depositphotos_28336025-stock-photo-clothes-on-a-rack.jpg",
    "https://www.shutterstock.com/image-photo/vintage-red-shoes-on-white-260nw-92008067.jpg",
    "https://i.pinimg.com/736x/c9/0d/91/c90d91426ae3384073474a42ab38f695.jpg"
  ];
  color =[
    {
      name: "الاسود",
      code: "#000000"
    },
    {
      name: "الابيض",
      code: "#FFFFFF"
    },
    {
      name: "زيتون",
      code: "#808000"
    },
    {
      name: "تركواز",
      code: "#008080"
    },
    {
      name: "أرجواني",
      code: "#800080"
    },
    {
      name: "الأزرق الداكن",
      code: "#000080"
    },
  ];
  size =[
    "S","L","XL","M"
  ]
  showUpArrow: boolean = false;
  showDownArrow: boolean = true;
  open:boolean =false;
  selectedImage: string = this.list[0];
  selectedColor: string = this.color[0].name;
  selectedSize: string = this.size[0];
  quantityNumber : number = 1;
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

  showImage(event: any): void {
    if (event.target.tagName === 'IMG') {
      this.selectedImage = event.target.src;
    }
  }
  selectColor(colorName: string): void {
    
    this.selectedColor = colorName;
  }
  selectSize(sizename: string): void {
    
    this.selectedSize = sizename;
  }
  plus(){
    this.quantityNumber++;
  }
  minus(){
    if (this.quantityNumber>1){
      this.quantityNumber--;
    }
  }
  toggle(){
    var div = document.getElementById("descptionProductString");
    div?.classList.toggle('active');
    if(this.open == true ){
      this.open = false;
    }else{
      this.open =true;
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

  prevPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }

  getTotalPages(): number {
    return Math.ceil(this.list.length / this.itemsPerPage);
  }
}
