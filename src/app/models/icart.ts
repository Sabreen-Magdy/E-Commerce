export interface CartDto {
  totalPrice: number;
  totalQuantity: number;
  items: CartItemDto[];
}


export interface CartItemDto {
  id: number;
  productId:number;
  productVarientId: number;
  image: string;
  name: string;
  size: string;
  color: string;
  discount: number,
  unitPrice: number;
  state: number;
  quantity: number;
  originalQuantity: number
}




export interface AddCart{
  productVarientId:number,
  state:number,
  quantity: number,
}
export interface Uppdatecart{
  
    state: number,
    quantity: number
  
}