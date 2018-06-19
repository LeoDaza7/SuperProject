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
    this.allService.getObject("api/getCart", "User").subscribe(
      response => {
        this.carrito = response;
        this.getProducts();
      },
      error => {
        console.log(error);
      }

    );
  }
  getProducts(){
    this.carrito.listPC.forEach(pc => {
      let tmp = this.allService.getObject("api/getproducts",pc.productCode).subscribe(
        response => {
          this.products.push(tmp);
        },
        error => {
          console.log(error);
        }
      );
      
    });

  }
}
