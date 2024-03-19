import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Iproduct } from 'src/app/Component/Models/iproduct';
import { ProductService } from 'src/app/Component/services/product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class     ProductDetailsComponent
{
  ProductList: any;
delete(arg0: any) {
throw new Error('Method not implemented.');
}
  product: Iproduct | undefined = {
    id: 3,
    name: 'test',
    description: 'test',
    discount: 3,
    price: 122,
    onSale: false,
    quantity: 0,
    img: 'https://images.pexels.com/photos/18105/pexels-photo.jpg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
  };

  id: number = 3;
  constructor(
    private activeRoute: ActivatedRoute,
    private proService: ProductService,
    private myRouter: Router
  ) {}
  ngOnInit(): void {
    this.id = this.activeRoute.snapshot.params['id'];
    this.product = this.proService.getById(this.id);
    // if (this.product === undefined) {
    //   this.myRouter.navigate(['/tt']);
    // }
  }

}
