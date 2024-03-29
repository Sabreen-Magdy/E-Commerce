export interface CartDto {
  totalPrice: number;
  totalQuantity: number;
  items: CartItemDto[];
}


export interface CartItemDto {
  id: number;
  productVariantId: number;
  image?: string;
  name: string;
  size: string;
  color: string;
  unitPrice: number;
  state: number;
  quantity: number;
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