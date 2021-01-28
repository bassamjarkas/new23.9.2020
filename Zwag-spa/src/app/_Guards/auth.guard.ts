import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthServiceService } from '../Services/AuthService.service';
import { AlertifyService } from '../Services/Alertify.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

constructor(private Authser:AuthServiceService,private alertify:AlertifyService,private roter:Router) {


  }
  canActivate(): boolean  {
    if (this.Authser.loggedIn()){
    return true;}
    this.alertify.Error("Du Muss Anmelden");
    this.roter.navigate([''])
    return false;
  }

}
