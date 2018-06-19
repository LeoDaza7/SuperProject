import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  getUserData = {}
  constructor(private _http: HttpService) { }

  ngOnInit() {
  }

  authUser() {
    this._http.getObject("getuser","UsernameExample")
    .subscribe(
      res => console.log(res),
      err => console.log(err)
    )
  }

}
