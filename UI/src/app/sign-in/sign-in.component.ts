import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  getUserData = {}
  constructor(private _http: HttpService) { }

  ngOnInit() {
  }

  addUser() {
    this._http.postObject(this.getUserData,"postuser")
    .subscribe(
      res => console.log(res),
      err => console.log(err)
    )
  }

}
