import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  getUserData = {}
  isCreated : boolean = false;
  isDuplicated : boolean = false;
  isError : boolean = false;

  constructor(private _http: HttpService) { }

  ngOnInit() {
  }

  addUser() {
    this._http.postObject(this.getUserData,"postuser")
    .subscribe(
      res => {
        
        this.isCreated = true;
        this.isDuplicated = false;
        this.isError = false;
      },
      err => {
        
        this.getUserData = {};
        if(err.status == 417){
          this.isDuplicated =  true;
          this.isCreated = false;
          this.isError = false;
        } else {
          this.isError = true;
          this.isCreated = false;
          this.isDuplicated = false;
        }
      }
    )
  }

}
