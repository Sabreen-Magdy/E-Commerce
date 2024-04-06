export interface IRegisteration {

    name: string,
    image: string,
    email: string,
    password: string,
    phone: string,
    address: string
      
}

export interface Ireset{
    token:string,
    otp: string,
    id: number,
    newPassword: string
}