export interface IReview {
  rate: number;
  content: string;
  name: string;
  region: string;
}

export interface ProductIReview {
  productId: number;
  productName: string;
  customerId: number;
  customerName: string;
  review?: string;
  rate: number;
  date: Date;
}

