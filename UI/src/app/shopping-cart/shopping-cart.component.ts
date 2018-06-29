import { Component, OnInit } from '@angular/core';
import { Cart } from '../models/cart';
import { ProductCart } from '../models/productCart';
import { Store } from '../models/store';
import { Product } from '../models/product';
import { HttpService } from '../http.service';
import { CookieService } from 'ngx-cookie-service';
import { User } from '../models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  constructor(private allService: HttpService, private cookie: CookieService, private router: Router) { 
    
  }
  
  
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
    }
    
  }

  delete(prod:number){
    
    this.allService.updateObject("updatecart",this.products[prod].Code,this.products[prod].Code).subscribe(
      response => {
        this.totalItems -= this.carrito.ListPC[prod].Quantity;
        this.totalPrice -= this.products[prod].Price * this.carrito.ListPC[prod].Quantity;
        this.products.splice(prod, 1);
        this.carrito.ListPC.splice(prod,1);

      },
      error => {
        console.log(error);
      }
      );

  }

  buyIt(){

    if(this.products.find(p => p.ShippingDeliveryType == "normal" || p.ShippingDeliveryType == "express" || p.ShippingDeliveryType == "free"))
    {
      this.router.navigate(['/shipping-options']);
    }
    else {
      
      this.router.navigate(['/home']);
    }
  }
}
