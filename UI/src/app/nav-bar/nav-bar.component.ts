import { Component, OnInit } from '@angular/core';
import { DataSharingService } from '../data-sharing.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  show:boolean = true;

  constructor(private _shared: DataSharingService) { }

  ngOnInit() {
    //this.show = this._shared.getStatus();
  }

}
