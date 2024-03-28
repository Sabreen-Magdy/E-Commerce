export interface customerOrder{
    orderId: number,
    customerId: number,
    customerName: string,
    orderDate: string,
    confirmDate: string,
    state: number,
    orderTotalCost: number,
    customerAddress: string,
    productsperOrders: CustomerproductsperOrders[]
 
}

export interface CustomerproductsperOrders {
        quantity: number,
        productVarientI: number,
        "image": string,
        "productName": string,
        "totalCost": number
}