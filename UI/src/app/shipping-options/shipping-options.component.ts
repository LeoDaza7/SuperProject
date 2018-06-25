import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpService } from '../http.service';
import { ShippingAddresses } from '../models/shippingAddresses';

@Component({
  selector: 'app-shipping-options',
  templateUrl: './shipping-options.component.html',
  styleUrls: ['./shipping-options.component.css']
})
export class ShippingOptionsComponent implements OnInit {

  tmpAddress : ShippingAddresses;
  addressess : ShippingAddresses[];
  isCreated : boolean = false;
  isDuplicated : boolean = false;
  isError : boolean = false;

  @ViewChild('form') public contentModal;

  cuForm: FormGroup;
  constructor(fb: FormBuilder, private allService: HttpService) { 
    this.cuForm = fb.group({

      'identifier': new FormControl('', Validators.required),
      'line1': new FormControl('', Validators.required),
      'line2': new FormControl('', Validators.required),
      'city': new FormControl('', Validators.required),
      'phone': new FormControl('', Validators.required),
      'zone': new FormControl('', Validators.required),
  });

  }

  ngOnInit() {
    this.getAdressess();
  }

  deliver(){
    console.log("Order Send");
  }

  editAddress(identifier : string){
    this.tmpAddress = this.addressess.find(a => a.Identifier == identifier);

  }

  getAdressess(){
    this.allService.getObject("getshippingaddress","").subscribe(
      response => {
        if (response)
        this.addressess = response;

      console.log(response);
      },
      error => {
        console.log(error);
      }
    );

  }

  deleteAddress(){
    console.log("delete");
    this.allService.deleteObject("deleteshippingaddress",this.tmpAddress.Identifier).subscribe(
      response => {
        console.log("deleted",response);
      },
      error => {
        console.log(error);
      }
    );
  }

  createAddress(){
    console.log("create");
     this.tmpAddress = new ShippingAddresses();
     this.tmpAddress.Identifier = this.cuForm.controls['identifier'].value;
     this.tmpAddress.Line1 = this.cuForm.controls['line1'].value;
     this.tmpAddress.Line2 = this.cuForm.controls['line2'].value;
     this.tmpAddress.City = this.cuForm.controls['city'].value;
     this.tmpAddress.Phone = this.cuForm.controls['phone'].value;
     this.tmpAddress.Zone = this.cuForm.controls['zone'].value;

    this.allService.postObject(this.tmpAddress,"postshippingaddress").subscribe(
      response => {
        console.log("created",response);
        this.getAdressess();
        this.isCreated = true;
        this.isError = false;
      },
      error => {
        console.log(error);
        this.isCreated = false;
        this.isError = true;
      }
    );

  }

}
