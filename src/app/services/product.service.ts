import { Injectable } from '@angular/core';
import { Iproduct } from '../models/iproduct';
import { ProductList } from '../models/iproductlist';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  products: Iproduct[] | undefined;
  constructor() {
    this.products = ProductList;
  }

  getAll(): Iproduct[] | undefined {
    return this.products;
  }

  getById(id: number): Iproduct | undefined {
    return this.products?.find((p) => p.id == id);
  }

  counter: number = 20;
  add(item: Iproduct) {
    var product = { ...item };
    product.id = ++this.counter;

    this.products?.push(product);
  }
}
