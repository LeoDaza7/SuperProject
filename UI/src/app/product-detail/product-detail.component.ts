import { Component, OnInit } from '@angular/core';
import { Cart } from '../models/cart';
import { Store } from '../models/store';
import { Product } from '../models/product';
import { HttpService } from '../http.service';
import { DataSharingService } from '../data-sharing.service';

import { Router, ActivatedRoute } from '@angular/router';
import { ProductCart } from '../models/productCart';
import { CookieService } from 'ngx-cookie-service';
import { User } from '../models/user';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})


  

 
export class ProductDetailComponent implements OnInit {
  
  cookieValue = 'UNKNOWN';
  user:User = new User();
  show:boolean = true;
  state:string = '';
  log:boolean = false;
  text:string =''; 
  quantity:number = 0 ;
  cant: number;
  constructor(private _http: HttpService ,private router: Router,private id:ActivatedRoute, private allService:HttpService , private _shared: DataSharingService, private cookieService: CookieService) {   }
  products : Product[];
  product : Product;
  productCart: ProductCart;
  carrito : Cart;
  identifier : string;
  href : String;
  cad : string[];
  stores : Store[];

  ngOnInit() {
  
  //var cant = ((document.getElementById("cant") as HTMLInputElement).value);
  //var cant =(<HTMLInputElement>document.getElementById("cant")).value;
  //var data = cant.onselect.toString;
  console.log("hereeeeeeeeeeeeeeeee");
    //console.log(cant);
     this.user.LastName = this.cookieService.get('Lname');
    this.user.Name = this.cookieService.get('Name');
    this.user.Username = this.cookieService.get('User');
   
   console.log("user");
   console.log(this.user.Username); 
   console.log(this.user.LastName);
    this.getCart();
    this.getAllProducts();
    this.href = this.router.url;
    console.log(this.href);
    this.getId();
    console.log(this.id);
    
  }

  private changeInputVar(): void {
   console.log(this.cant);
  }

  getCart(){
    this.allService.getObject("getCart", this.user.Username).subscribe(
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
      },
      error => {
        console.log(error);
      }

    );
  }

  getProductCart(){
    this._http.getObject("getproductCart",this.identifier).subscribe(
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
   this.product = this.products.find(i => i.Code == this.identifier);
   console.log(this.product);

  }
  onClick(){
    var data = this.identifier;
    var object = new ProductCart();
     object.ProductCode= this.identifier;
    object.ShippingDeliveryType=this.product.ShippingDeliveryType;
    object.Store=this.getStore[0];
    object.Quantity=this.cant;
   this.getCart();
    var lista = this.carrito.ListPC;
    var result = false;
    var cant1 = this.cant;
    console.log(lista);
    lista.forEach(function(element){
     console.log(element.ProductCode);
      if (element.ProductCode== data ){
        result = true;
        var value = element.Quantity;
        element.Quantity = value+cant1;
        
      }else{}
    });

if(result==false){lista.push(object);}
console.log(lista);
this.carrito.ListPC=lista;
  this.addCart();
  }
  
  seeCart(){
    console.log(this.carrito.ListPC.length);

  }

  getId(){
this.cad = this.href.split("/");
this.identifier = this.cad[this.cad.length-1]; 
console.log(this.id);
  
  }
  addCart() {
    console.log("this is updating");
    console.log(this.carrito.ListPC);
    this.allService.deleteObject("deletecart",this.user.Username).subscribe(
      response => {
        console.log("deleted",response);
      },
      error => {
        console.log(error);
      }
    );
  
    this._http.postObject(this.carrito,"postcart")
    .subscribe(
      res => {
       console.log("ok");
      },
      err => {
        console.log("no");
      }
    )
  }
}
