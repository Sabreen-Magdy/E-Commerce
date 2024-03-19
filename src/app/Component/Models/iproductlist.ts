import { Iproduct } from './iproduct';

export let ProductList: Iproduct[] = [
  {
    id: 1,
    img: 'https://images.pexels.com/photos/170811/pexels-photo-170811.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
    name: 'car',
    description: 'car blue ',
    price: 200000,
    onSale: true,
    discount: 0.05,
    quantity: 2,
  },
  {
    id: 2,
    img: 'https://images.pexels.com/photos/699122/pexels-photo-699122.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
    name: 'phone',
    description: 'my phone ',
    price: 7000,
    onSale: false,
    discount: 0.1,
    quantity: 10,
  },
  {
    id: 3,
    img: 'https://images.pexels.com/photos/601316/pexels-photo-601316.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
    name: 'skirt',
    description: 'my skirt ',
    price: 500,
    onSale: true,
    discount: 0.25,
    quantity: 5,
  },
  {
    id: 4,
    img: 'https://images.pexels.com/photos/996329/pexels-photo-996329.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
    name: 't-shirt',
    description: 'my t-shirt ',
    price: 300,
    onSale: false,
    discount: 0.1,
    quantity: 0,
  },
  {
    id: 5,
    img: 'https://images.pexels.com/photos/18105/pexels-photo.jpg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
    name: 'laptop',
    description: 'my laptop ',
    price: 15000,
    onSale: true,
    discount: 0.15,
    quantity: 20,
  },
];
