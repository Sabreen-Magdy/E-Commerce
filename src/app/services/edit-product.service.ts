import { Uppdatecart } from 'src/app/models/icart';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IaddColoredImage, IaddVariant, ICategoryProduct, IcoloredImage, IProductDetilas, IupdateDetials, IupdateVariant, IVarient } from '../models/edit-product';

@Injectable({
  providedIn: 'root'
})
export class EditProductService {

  constructor( private http: HttpClient) { }

  BaseUrl : string ="http://localhost:5058/api/";
  

  /** ------------------   get         ------------------- */

  getonlyDetailsById (id :number) : Observable<IProductDetilas>  
  {
    return this.http.get<IProductDetilas>(`${this.BaseUrl}Product/GetDetailsById?id=${id}`)  

  }

  getCategoryById (id : number) : Observable <ICategoryProduct[]>
  {
    return this.http.get<ICategoryProduct[]>(`${this.BaseUrl}Product/GetCategories?id=${id}`)
  }
  getVariantsById (id : number) : Observable<IVarient[]>
  {
    return this.http.get<IVarient[]>(`${this.BaseUrl}Product/GetVarientsById?id=${id}`)
  }

  getProductImages (id : number) : Observable<IcoloredImage[]>
  {
    return this.http.get<IcoloredImage[]>(`${this.BaseUrl}Product/GetProductImages?id=${id}`)
  }
  
  /*---------------  delete ----------------------*/ 

  deleteVariant (id :number ) {
    return this.http.delete(`${this.BaseUrl}Saller/DeleteVarient?id=${id}`)
  }
  
  

  deleteProductImages (id : number)  {
      return this.http.delete(`${this.BaseUrl}Saller/DeleteColor?id=${id}`)
  }
  
 
  deleteCatgoryofProduct (idProd:number , CatgId:number ) {
    return this.http.delete(`${this.BaseUrl}Saller/DeleteCategoryByProductColor?productId=${idProd}&categoryId=${CatgId}`)
  }

  /*---------------  Add ----------------------*/
  
  addVariant (varient : IaddVariant) {
    return this.http.post(`${this.BaseUrl}Saller/AddVarient`,varient)
  }
 
  addProductImages (coloredImage : IaddColoredImage){
    return this.http.post(`${this.BaseUrl}Saller/AddColor`,coloredImage)
  }

  // addProductImages (coloredImage : IaddColoredImage){
  //   return this.http.post(`http://localhost:5058/api/Saller/AddColor`,coloredImage)
  // }
  addCategoryToprodutc (prodId : number, categId :number) {
    return this.http.post(`${this.BaseUrl}Saller/AddCategory?productId=${prodId}&categoryId=${categId}`,{})
  }

  /*---------------  update ----------------------*/

  updateDetials (id : number , update : IupdateDetials){
    return this.http.put(`${this.BaseUrl}Saller/Update?id=${id}`,update)
  }

  /****----------تحت الاعداد--------------- */
  updateVarient (id : number , update : IupdateVariant){
    return this.http.put(`${this.BaseUrl}Saller/UpdateVarient?id=${id}`,update)
  }
}

