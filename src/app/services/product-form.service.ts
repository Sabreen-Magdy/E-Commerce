
// import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IProductAddForm, IproductShow } from '../models/i-product-variant';

interface catNameWithList
{
  nameCateg : string;
  categList : IproductShow[];
}
@Injectable({
  providedIn: 'root'
})
export class ProductFormService  implements OnInit{

  allNumber : number = 0;
  baseURL : string ="http://www.srm.somee.com/api/Saller/";
  baseURL2 : string = "http://www.srm.somee.com/api/Product/";

  productsCache: IproductShow[] = [];
  listCategoryBYname : catNameWithList [] = [];
  cuurentCategName : string = "";


  constructor( private http:HttpClient) { }
  ngOnInit(): void {
    
  }

  getlength()
  {
    this.http.get<number>(`${this.baseURL2}GetNumberProducts`).subscribe({
      next:(data) => {
        console.log(data);
        this.allNumber = data;
      }
    })
  }

  

 
  addProduct(product:IProductAddForm ): Observable<any> {
    return this.http.post<any>(`${this.baseURL}Add`, product)
  }

  fetchAndCacheProducts(): Observable<IproductShow[]> {
    console.log("fetch");
    console.log(this.allNumber);
    if (this.productsCache.length == 0 || this.productsCache.length != this.allNumber) {
      console.log("fetch form service");
      return this.http.get<IproductShow[]>(`${this.baseURL2}GetAll`).pipe(
        tap(products => this.productsCache = products) // Cache the products
      );
    }
    else {
      console.log("catch form our");

      return of(this.productsCache);
    }
  }

  getAllProduct2(): Observable<IproductShow[]> {
    console.log(this.productsCache);
    console.log("getAllproduct2");
    return this.fetchAndCacheProducts();
  }

  isCurrentCategoryInList(): boolean {
    console.log("start iscurrentCateg");
    console.log(this.cuurentCategName);
    console.log(this.listCategoryBYname);
    const existingCategoryIndex = this.listCategoryBYname.findIndex(item => item.nameCateg === this.cuurentCategName);

    return !(existingCategoryIndex == 0)
  }

  fetchAndCacheProducts2(): Observable<IproductShow[]> {
    console.log("we are now in fetch carProduct");
    let res =  this.isCurrentCategoryInList();
    console.log(res);
    if (res ) {
      console.log("fetch form service for cate");
      console.log(this.isCurrentCategoryInList());
      return this.http.get<IproductShow[]>(`${this.baseURL2}GetByGetegory?gategory=${this.cuurentCategName}`).pipe(
        tap( catProduct => {
            console.log(catProduct);
              let newCategory : catNameWithList = {
                nameCateg: this.cuurentCategName,
                categList: catProduct
              }

           // Check if the current category exists in listCategoryBYname
            const existingCategoryIndex = this.listCategoryBYname.findIndex(item => item.nameCateg === this.cuurentCategName);

            if (existingCategoryIndex !== -1) {
              console.log("there are before");
              this.listCategoryBYname.splice(existingCategoryIndex, 1);
            }
            
            // Add the new category entry
            this.listCategoryBYname.push(newCategory);
            console.log(this.listCategoryBYname);
        }
      )
      );
    }  
    else {

      console.log("osjsk");
      // If products are cached, return the cached products as an Observable
      const filteredCategory = this.listCategoryBYname.find(item => item.nameCateg === this.cuurentCategName);
      console.log(filteredCategory);
      if (filteredCategory) {
        return of(filteredCategory.categList);
      } else {
        return of([]);
      }
    }
  }

  gatProductbyCategoryName2(catName : string) : Observable <IproductShow[]>
  {
    this.cuurentCategName = catName;
    console.log("currentCateg in get",this.cuurentCategName);
    return this.fetchAndCacheProducts2();
  }

  // getState(){
  //   if (this.productsCache.length == 0) {

  //   }
  // }


  getAllProduct () : Observable <IproductShow[]> {
    return this.http.get<IproductShow[]>(`${this.baseURL2}GetAll`)
  }

  gatProductbyCategoryName(catName : string) : Observable <IproductShow[]>
  {
    return this.http.get<IproductShow[]>(`${this.baseURL2}GetByGetegory?gategory=${catName}`)
  }

  getProductByName (prodName : string) : Observable<IproductShow[]> {
    return this.http.get<IproductShow[]>(`${this.baseURL2}GetByName?name=${prodName}`)
  }

  deleteProduct (id : number) {
    return this.http.delete(`${this.baseURL}DeleteProduct?id=${id}`)
  }

}
