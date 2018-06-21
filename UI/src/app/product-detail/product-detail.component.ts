import { Component, OnInit } from '@angular/core';
import { Cart } from '../models/cart';
import { Store } from '../models/store';
import { Product } from '../models/product';
import { HttpService } from '../http.service';

import { Router,ActivateRoute } from '@angular/router';
import { ProductCart } from '../models/productCart';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})


  

 
export class ProductDetailComponent implements OnInit {

  constructor(private _http: HttpService ,private router: Router,private id:ActivateRoute ) { this.id.params.subscribe(p => this.id)}
 
  products : Product[];
  product : Product;
  productCart: ProductCart;
  carrito : Cart;
  id : String;
  href : String;
  cad : String[];
  stores : Store[];

  ngOnInit() {
    this.getCart();
    this.getAllProducts();
    this.href = this.router.url;
    console.log(this.href);
    this.getId();
    console.log(this.id);
    
  }


  getCart(){
    this.allService.getObject("getCart", "user1").subscribe(
      response => {
        console.log(response);
        this.carrito = response;
        //if (this.carrito.listPC)
      },
      error => {
        console.log(error);
      }

    );
  }

getStore(){
    this.allService.getObject("getStore",null).subscribe(
      response => {
        console.log(response);
        this.stores = response;
        //if (this.carrito.listPC)
      },
      error => {
        console.log(error);
      }

    );
  }

  getProductCart(){
    this._http.getObject("getproductCart",this.id).subscribe(
      response => {
        console.log(response);
        this.productCart = response;
      

      },
      error => {
        console.log(error);
      }

    );
  }
  getAllProducts(){
    this._http.getObject("getproducts",null).subscribe(
      res=>{
        console.log(res)
        this.products = res;
        this.getSpecific();

      },
      err=>{
        console.log(err)
      });
  }
  getSpecific(){
   this.product = this.products.find(i => i.Code == this.id);
   console.log(this.product);

  }
  onClick(){
    //this.carrito.listPC.push(new productCart(this.product.));
  }
  getId(){
this.cad = this.href.split("/");
this.id = this.cad[this.cad.length-1]; 
console.log(this.id);
  
  }
 

}