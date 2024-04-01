import { Component } from '@angular/core';
import { Iproduct } from 'src/app/models/iproduct';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.component.html',
  styleUrls: ['./addproduct.component.css'],
})
export class AddproductComponent {
  ProductList: Iproduct[] = [];
  p:number = 1;

  constructor(private prodService: ProductService) {}

  ngOnInit(): void {
    this.ProductList = this.prodService.getAll() as Iproduct[];
  }

  delete(id: number) {
    this.ProductList = this.ProductList.filter((p) => p.id != id);
    // call service `delete` method to remove the product with passed parameter `id`
  }
}
