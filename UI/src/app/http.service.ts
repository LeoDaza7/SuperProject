import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  private _serviceUrl = "http://localhost:55014"
  constructor(private http: HttpClient) { }
  postUser(user){
    let _serviceUri = this._serviceUrl+"/api/postuser";
    return this.http.post<any>(_serviceUri, user)
  }
}
