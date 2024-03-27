export interface Icart {
  Id:number;
TotalPrice :number
 TotalQuantity :Number
 ITem:Item[]
}
export interface Item {
  
  id:Number;
  img:string;
  Name:string;
  Description:String;
  Quantitiy:number;
  price:number

}