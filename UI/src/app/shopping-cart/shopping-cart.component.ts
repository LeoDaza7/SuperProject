import { Component, OnInit } from '@angular/core';
import { Cart } from '../models/cart';
import { ProductCart } from '../models/productCart';
import { Store } from '../models/store';
import { Product } from '../models/product';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  constructor(private allService: HttpService) { }
  
  products : Product[];
  carrito : Cart;
  store: Store;
  totalItems: number = 0;
  totalPrice: number = 0;
  ngOnInit() {

    this.getCart();

  }

  getCart(){
    this.allService.getObject("getCart", "user1").subscribe(
      response => {
        console.log(response);
        this.carrito = response;
        //if (this.carrito.listPC)
          this.getProducts();
      },
      error => {
        console.log(error);
      }

    );
  }
  getProducts(){
    // this.carrito.listPC.forEach(pc => {
    //   this.allService.getObject("getproducts",pc.productCode).subscribe(
    //     response => {
    //       this.products.push(response);
    //       this.products.forEach(p => {
    //       this.totalPrice += p.price;
          
    //     });
    //       this.totalItems += pc.quantity
    //     },
    //     error => {
    //       console.log(error);
    //     }
    //   );
      
    // });

    this.allService.getObject("getproducts","").subscribe(
      response => {
        console.log(response);
        this.products = response;
        this.products.forEach(p => {
          this.totalPrice += p.Price;
          
        });

      },
      error => {
        console.log(error);
      }

    );
  }
}
