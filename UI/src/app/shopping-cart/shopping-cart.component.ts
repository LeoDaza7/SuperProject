import { Component, OnInit } from '@angular/core';
import { Cart } from '../models/cart';
import { ProductCart } from '../models/productCart';
import { Store } from '../models/store';
import { Product } from '../models/product';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  constructor() { }
  
  product : Product;
  items : ProductCart[] = [];
  carrito : Cart;
  store: Store;
  ngOnInit() {
    this.store = new Store();
    this.store.name = "Oxxo";
    this.store.lane1 = "Lane1";
    this.store.lane2 = "LaneUno";
    this.store.phone = 79763702;

    this.items.push({productCode : "ABCssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss", shippingDeliveryType: 2, store : this.store, quantity : 5})
    this.items.push({productCode : "123", shippingDeliveryType: 4, store : this.store, quantity : 2})
    this.items.push({productCode : "JQK", shippingDeliveryType: 1, store : this.store, quantity : 1})
    this.items.push({productCode : "456", shippingDeliveryType: 3, store : this.store, quantity : 7})
    this.items.push({productCode : "456", shippingDeliveryType: 3, store : this.store, quantity : 7})
    this.items.push({productCode : "456", shippingDeliveryType: 3, store : this.store, quantity : 7})
    this.items.push({productCode : "456", shippingDeliveryType: 3, store : this.store, quantity : 7})

    this.items.forEach(i => {
      console.log("Call the service");
    });
    console.log(this.items);
    
  }

}
