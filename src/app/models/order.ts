import { Payment } from './payment';
export interface IorderAdd 
{
    customerId: number,
    orderDate: string,
    customerAddress: string,
    productsperOrder: IproductforOrderadd[]
}


export interface IproductforOrderadd 
{
    productVarientId: number,
    quantity: number,
    totalCost: number
}
export interface AddPaymentOrder
{
    order :IorderAdd
    payment : Payment
}
