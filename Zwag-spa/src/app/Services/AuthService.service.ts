import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Token } from '@angular/compiler/src/ml_parser/lexer';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from "rxjs/operators";


@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
Jwthelper=new JwtHelperService();
decodedTocken:any;
  Baseurl=environment.apiUrl+"Auth/";
constructor(private http:HttpClient) { }

login(model:any){
return this.http.post(this.Baseurl+'login',model).pipe(

  map((Response:any)=>{
    const user =Response;
    if (user){
      localStorage.setItem("token",user.token);
      this.decodedTocken=this.Jwthelper.decodeToken(user.token);
      console.log(this.decodedTocken);

    }}));}

   register(model:any){
     return this.http.post(this.Baseurl+"register",model);
   }

   loggedIn(){
     try{const token=localStorage.getItem("token");
     return ! this.Jwthelper.isTokenExpired(token);}
     catch{return false}
   }

}

