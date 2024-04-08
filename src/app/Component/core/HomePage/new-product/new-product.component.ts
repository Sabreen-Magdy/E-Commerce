import { Subscription } from 'rxjs';
import Swal from 'sweetalert2';
import { AuthService } from 'src/app/auth.service';
import { favitem, IaddFavorite } from 'src/app/models/Ifav';
import { IproductShow } from 'src/app/models/i-product-variant';
import { FavoriteService } from 'src/app/services/favorite.service';
import { ProductFormService } from 'src/app/services/product-form.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css'],
})
export class NewProductComponent implements OnInit {
  allproductList: IproductShow[] = [];
  FavList : favitem [] = [];
  isFav : boolean = false;
  customerId: number = 0;
  categoryName: string = '';
  thiscateg: boolean = false;
  constructor(
    private prodServ: ProductFormService,
    private _cart: CartService,
    private _authService: AuthService,
    private _favService: FavoriteService,
    private activeRoute: ActivatedRoute,
    private route: Router
  ) {}

  ngOnInit(): void {
    this._cart.getNumberOfitemInCart();
    this._favService.getNumberOfitemInFavCart();
    this.customerId = this._authService.id;
    this.prodServ.getlength();
    this.activeRoute.params.subscribe((params) => {
      this.categoryName = params['catgoryname'];
      console.log(this.categoryName); // Convert the parameter to a number
      if (this.categoryName) {
        this.thiscateg = true;
        console.log(this.categoryName);
        this.prodServ.gatProductbyCategoryName2(this.categoryName).subscribe(
          (products) => {
            products.sort((a, b) => b.addingDate.localeCompare(a.addingDate));
            this.allproductList = products;
          },
          (error) => {
            console.error('Error fetching products:', error);
          }
        );
      } else {
        this.prodServ.getAllProduct2().subscribe(
          (products) => {
            products.sort((a, b) => b.addingDate.localeCompare(a.addingDate));
            this.allproductList = products;
          },
          (error) => {
            console.error('Error fetching products:', error);
          }
        );
      }
    });
    if (this.customerId != 0){
      this.getALLfav();
    }
  }

  AllProductSub: Subscription | undefined;
  addFavSub: Subscription | undefined;
  delFavSub : Subscription | undefined;
  getAllFavSub: Subscription | undefined;

  pushItemToFavCart(prodId: number) {
    this._authService.userData.subscribe({
      next: () => {
        if (this._authService.userData.getValue() != null) {
          
          const addFav: IaddFavorite = {
            customerId: this.customerId,
            productId: prodId,
          };

          this.addFavSub = this._favService.additemTofav(addFav).subscribe({
            next: (data) => {
              // Swal.fire({
              //   title: 'تم إضافة المنتج إلى قائمة أمنياتك',
              //   confirmButtonColor: '#198754', // Change this to the color you prefer
              // });
              Swal.fire({
                position : 'top-right',
                // icon : 'success',
                showCancelButton : false,
                showConfirmButton : false,
                timer:700,
                titleText:'تم إضافة المنتج إلى قائمة أمنياتك',
                color:'green',
                
              });
              console.log('item Add to Fav Succesfully' + data);
              this._favService.getNumberOfitemInFavCart();
              this.getALLfav();
            },
            error: (e) => {
              console.log('may bt item in fav already');
              console.log('ERROR when add fav to item' + e);
            },
          });
          this._favService.getNumberOfitemInFavCart();
        } else {
          Swal.fire({
            title: 'سجل دخول حتى تتمكن من رحلة التسوق معنا!',
            confirmButtonColor: '#198754', // Change this to the color you prefer
          });
        }
      },
    });
  }
  getALLfav(){
    this.getAllFavSub =this._favService.getallFavbycustomr(this.customerId).subscribe({
      next: (d)=>{
        this.FavList = d;
      },
      error : (e) => {
        console.log("ERROR");
        console.log(e);
      }
    })
  }
  deleteFav(prodId : number){
    this.delFavSub = this._favService.deletefavitem(this.customerId,prodId).subscribe({
      next : (d)=>{
        console.log("Delete Successfully");
        // Swal.fire({
        //   title: 'تم ازالة المنتج من قائمة أمنياتك',
        //   confirmButtonColor: '#198754', // Change this to the color you prefer
        // });
        Swal.fire({
          position : 'top-right',
          // icon : 'success',
          showCancelButton : false,
          showConfirmButton : false,
          timer:700,
          titleText:'تم ازالة المنتج من قائمة أمنياتك' ,
          color:'red',
          
        });
        this.getALLfav();
        this._favService.getNumberOfitemInFavCart();
      },
      error : (e)=>{
        console.log(e);
      }
    })
  }
  goto() {
    if (this.thiscateg) {
      this.route.navigate([`/store/${this.categoryName}`]);
    } else {
      this.route.navigate([`/store`]);
    }
  }

  hoverfun(id: number) {
    console.log("hiiiiiii",id);
    console.log(this.FavList);
    for (let iten of this.FavList){
      if (iten.productId == id){
        this.isFav = true
        console.log(true);
      }
    }
  }
  unhoverfun(id: number) {
    console.log('bye', id);
    this.isFav = false;
  }
}
