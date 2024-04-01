export interface IProductDetilas {

    id: number,
    name: string,
    avgRating: number,
    numberReviews: number,
    description: string

}

export interface IVarient 
{
    id: number,
    price: number,
    discount: number,
    offerPrice: number,
    priceAfter: number,
    quantity: number,
    code: string,
    colorName: string,
    coloredimage: string,
    size: string
}


export interface IcoloredImage 
{
    id: number,
    colorCode: string,
    colorName: string,
    image: string
}

export interface ICategoryProduct {
    id: number,
    name:string
}
export interface IaddVariant {
    
    productId: number,
    colorId: number,
    unitPrice: number,
    discount: number,
    quantity: number,
    sizeId: number

}

export interface IaddColoredImage {
    
    productId: number,
    colorId: number,
    image: string
      
}


export interface IupdateDetials {
    
    name: string,
    description : string
           
}

/**تحت الاعداد */
export interface IupdateVariant {
    
    unitPrice: string,
    discount: string,
    quantity: string
      
}