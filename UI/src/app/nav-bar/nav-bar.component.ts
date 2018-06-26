import { Component, OnInit } from '@angular/core';
import { DataSharingService } from '../data-sharing.service';

import { CookieService } from 'ngx-cookie-service';
import { User } from '../models/user';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  cookieValue = 'UNKNOWN';
  user:User = new User();
  show:boolean = true;

  constructor(private _shared: DataSharingService, private cookieService: CookieService) {
    this.user.Name="";
    this.user.LastName="";
  }

  ngOnInit() {
    //this.show = this._shared.getStatus();
    this.user.LastName = this.cookieService.get('Lname');
    this.user.Name = this.cookieService.get('Name');
  }

}
