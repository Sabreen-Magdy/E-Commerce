export interface IproductVarDet {
    id: number;
    price: number;
    discount: number;
    offerPrice: number;
    priceAfter: number;
    quantity: number;
    code: string;
    coloredimage: string;
    size: string
    colorName:string
}

export interface IproductByGategory {
    id: number;
    image: string;
    name: string;
    // description: string;
    price: number;
    // onSale: boolean;
    // discount: number;
    quantity: number;
    avgRating:number;
    addingDate:string;
   
}
