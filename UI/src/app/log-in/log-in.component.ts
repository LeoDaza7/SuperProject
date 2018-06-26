import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { NgForm } from '@angular/forms';
import { User } from '../models/user';
import { DataSharingService } from '../data-sharing.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {
  cookieValue = 'UNKNOWN';
  getUserData = {}
  constructor(private _http: HttpService,private _shared: DataSharingService, private cookieService: CookieService) { }
  user: User;
  public username;
  
  ngOnInit() {
    
  }
  onSubmit(f: NgForm) {
    this.authUser(f.value.Username);
    this._shared.setStatus(true)
  }
  authUser(key:string) {
    this._http.getObject("getusers",key)
    .subscribe(
      res => {
        console.log(res)
        this.user = res;
        this.username = this.user.Username;
        this._shared.setStatus(true);
        this.cookieService.set('User',this.username);
        this.cookieService.set('Name',this.user.Name);
        this.cookieService.set('Lname',this.user.LastName);
      },
      err => {console.log(err)
        this.cookieService.set('User','');
        this.cookieService.set('Name','');
        this.cookieService.set('Lname','');
      }

    )
  }
}
