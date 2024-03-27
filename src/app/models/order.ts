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

