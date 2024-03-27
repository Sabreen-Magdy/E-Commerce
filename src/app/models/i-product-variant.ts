import { ColoredProduct } from "./colored-product"

export interface IProductAddForm {
  sallerId: number,
  name: string,
  description: string,
  categories: number[],
  images: ColoredProduct[],
  productVariants: IProductVariant []

} 

export interface IProductVariant {
  
    colorId: number,
    unitPrice: number,
    discount: number,
    quantity: number,
    sizeId: number
  
}

export interface IproductShow {
  
    id: number,
    name: string,
    price: number,
    image: string
  
}

