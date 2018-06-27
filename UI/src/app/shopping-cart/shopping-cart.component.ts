import { Component, OnInit } from '@angular/core';
import { Cart } from '../models/cart';
import { ProductCart } from '../models/productCart';
import { Store } from '../models/store';
import { Product } from '../models/product';
import { HttpService } from '../http.service';
import { CookieService } from 'ngx-cookie-service';
import { User } from '../models/user';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  constructor(private allService: HttpService, private cookie: CookieService) { }
  
  products : Product[] = [];
  carrito : Cart;
  store: Store;
  totalItems: number = 0;
  totalPrice: number = 0;
  user : string = "";
  ngOnInit() {
    this.user = this.cookie.get('User');
    this.getCart();

  }

  getCart(){
    this.allService.getObject("getCart", this.user).subscribe(
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
    
    if (this.carrito.ListPC){
      this.carrito.ListPC.forEach(pc => {
        this.allService.getObject("getproducts",pc.ProductCode).subscribe(
          response => {
            console.log("products",pc);
            this.products.push(response);
            this.totalPrice += response.Price * pc.Quantity;
            this.totalItems += pc.Quantity
          },
          error => {
            console.log(error);
          }
        );
        
      });        
    });  
    }
    
  }
}
