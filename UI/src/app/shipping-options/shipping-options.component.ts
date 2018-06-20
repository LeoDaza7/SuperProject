import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { NgForm } from '@angular/forms';
import {ShippingOptions} from './shipping-options.model';
import {User} from '../user.model';
@Component({
  selector: 'app-shipping-options',
  templateUrl: './shipping-options.component.html',
  styleUrls: ['./shipping-options.component.css'],
  providers:[ShippingOptionsService]
})
export class ShippingOptionsComponent implements OnInit {

  constructor(private allService: HttpService) { }

  shippingAddresses : ShippingOptions[];
  user : User;

  ngOnInit() {
  this.getShippingOptions();
  }

  resetForm(form?: NgForm) {
   if (form != null)
      form.reset();
    this.allService = {
    Identifier : null;
    Line1 : '';
    Line2 : '';
    Phone : '';
    City : '';
    Zone : '';
    }
  }
  

  getShippingOptions(){
    this.user.ShippingAddresses.forEach(result => {
      this.allService.getObject("api/getshippingoptions",result.Identifier).subscribe(
        response => {
          this.ShippingAddresses.push(response);
        },
        error => {
          console.log(error);
        }
      );
      
    });

  }

  onSubmit(form: NgForm) {
    if (form.value.Identifier == null) {
      this.allService.postObject("api/postshippingoptions",Codeform.value)
        .subscribe(data => {
          this.resetForm(form);
          
        })
    }
    
  }

}
