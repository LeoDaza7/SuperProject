import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ShippingAddress } from '../models/shipping-address';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-shipping-options',
  templateUrl: './shipping-options.component.html',
  styleUrls: ['./shipping-options.component.css']
})
export class ShippingOptionsComponent implements OnInit {

 getdata = {}
  constructor(private service: HttpService) { }

  shippingAddresses : ShippingAddress[];
  

  ngOnInit() {
  this.getShippingAddresses();
  }

  resetForm(form?: NgForm) {
   if (form != null)
      form.reset();
    this.getdata = {
    Identifier : null,
    Line1 : '',
    Line2 : '',
    Phone : '',
    City : '',
    Zone : '',
    }
  }

  getShippingAddresses(){
    this.service.getObject("getshippingAddresses",null).subscribe(
      res=>{
        console.log(res)
        this.shippingAddresses = res;
      },
      err=>{
        console.log(err)
      });
  }

  postShippingAddresses() {
    this.service.postObject(this.getdata,"postshippingAddresses")
    .subscribe(
      res => console.log(res),
      err => console.log(err)
    )
  }

}
