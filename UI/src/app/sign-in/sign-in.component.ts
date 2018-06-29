import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ToasterService } from 'angular2-toaster';
import { Router } from '@angular/router';

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

  constructor(private _http: HttpService, private toasterService : ToasterService, private router: Router) { }

  ngOnInit() {
  }

  addUser() {
    this._http.postObject(this.getUserData,"postuser")
    .subscribe(
      res => {
        
        this.isCreated = true;
        this.isDuplicated = false;
        this.isError = false;
        this.popToast('User added Succesfully');
        this.router.navigate(['/log-in']);
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

  popToast(message : string) {
    this.toasterService.pop('success', 'DONE', message);
  }

}
