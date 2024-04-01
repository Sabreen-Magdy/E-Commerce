import { AdminOrderProducts } from "./admin-order-products";

export interface AdminOrder {
    orderId: number;
    cutomerId :number
    customerName :string
    orderDate :string
    confirmDate:string|null
    state: number
    orderTotalCost: number
    customerAddress: string
    comment:string;
    productsperOrders :AdminOrderProducts[]
}
