import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  constructor() { }
  product: {
    nombre : string;
    price: number;
    tipoDeEntrega: string[];
    tiendaARecoger: string[];
    cantidad: number;
  };
  carrito : any[] = [];

  ngOnInit() {
    this.product = {
      nombre : "Laptop",
      price: 520,
      tipoDeEntrega: ["auto", "bici"],
      tiendaARecoger: ["central"],
      cantidad: 1
    };
    this.carrito.push(this.product);
    this.product = {
      nombre : "Celular",
      price: 320,
      tipoDeEntrega: ["auto"],
      tiendaARecoger: ["Sucursal 1"],
      cantidad: 1
    };
    this.carrito.push(this.product);
    this.product = {
      nombre : "Reloj",
      price: 420,
      tipoDeEntrega: ["auto", "bici", "Correo"],
      tiendaARecoger: ["central", "Sucursal 2"],
      cantidad: 1
    };
    this.carrito.push(this.product);
  }

}
