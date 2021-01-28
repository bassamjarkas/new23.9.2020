import { environment } from 'src/environments/environment';
import { User } from '../_Models/User';
import { Observable } from 'rxjs';

import { HttpClient, HttpHeaders } from '@angular/common/http';


import { Injectable } from '@angular/core';
//import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseurl=environment.apiUrl+'user/';
constructor(private Http:HttpClient) { }

getUsers():Observable<User[]> {
  return this.Http.get<User[]>(this.baseurl);

}
getuser(id:any):Observable<User>{
return this.Http.get<User>(this.baseurl+id);

}

}
