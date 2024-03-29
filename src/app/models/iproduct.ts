import { IProductAddForm } from './i-product-variant';
export interface Iproduct {
  id: number;
  img: string;
  name: string;
  description: string;
  price: number;
  onSale: boolean;
  discount: number;
  quantity: number;

  // id: number;
  // name: string;
  // avgRating: number
  // numberReviews: number
  // description: string
}


