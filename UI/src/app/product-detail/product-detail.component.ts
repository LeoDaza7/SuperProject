import { Component, OnInit } from '@angular/core';
import { Cart } from '../models/cart';
import { Product } from '../models/product';
import { HttpService } from '../http.service';
import { ProductCart } from '../models/productCart';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  constructor(private allService: HttpService) { }

  products : Product[];
  product : Product;
  productCart: ProductCart;
  carrito : Cart;
  id : String;

  ngOnInit() {
    this.getCart();
    this.getProductCart();
    this.getProducts();
    this.getSpecific();
  }

  getCart(){
    this.allService.getObject("getCart", "user1").subscribe(
      response => {
        console.log(response);
        this.carrito = response;
       
          this.getProducts();
      },
      error => {
        console.log(error);
      }

    );
  }
  getProductCart(){
    this.allService.getObject("getproductCart",this.id).subscribe(
      response => {
        console.log(response);
        this.productCart = response;
       

      },
      error => {
        console.log(error);
      }

    );
  }
  getProducts(){

    this.allService.getObject("getproducts","").subscribe(
      response => {
        console.log(response);
        this.products = response;
      },
      error => {
        console.log(error);
      }

    );
  }
  getSpecific(){
   this.product = this.products.find(i => i.code === this.id);

  }
  onClick(){
    this.carrito.listPC.push(this.productCart);

  }

}
