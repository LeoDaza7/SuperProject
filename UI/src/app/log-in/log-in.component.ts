import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { NgForm } from '@angular/forms';
import { User } from '../models/user';
import { DataSharingService } from '../data-sharing.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {
  getUserData = {}
  constructor(private _http: HttpService,private _shared: DataSharingService) { }
  user: User;
  public username;
  ngOnInit() {
  }
  onSubmit(f: NgForm) {
    this.authUser(f.value.Username);
    this._shared.setStatus(true)
  }
  authUser(key:string) {
    this._http.getObject("getuser",key)
    .subscribe(
      res => {
        console.log(res)
        this.user = res;
        this.username = this.user.Username;
        this._shared.setStatus(true)
      },
      err => console.log(err)
    )
  }
}
