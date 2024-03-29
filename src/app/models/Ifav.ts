export interface Ifav{
 CustomerId:number
 ProductId :number
 Image :string;
 Name:string;
 Description :string;
 Price :number;
}



export interface favitem {

    id: number,
    customerId: number,
    productId: number,
    image: string,
    name: string,
    description: string,
    price: number
        
}

export interface IaddFavorite {
    customerId: number,
    productId: number
}
