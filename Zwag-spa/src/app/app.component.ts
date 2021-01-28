import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthServiceService } from './Services/AuthService.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  Jwthelper=new JwtHelperService();

  constructor(public authservice:AuthServiceService) {


  }
  ngOnInit() {
    const token=localStorage.getItem("token");
    this.authservice.decodedTocken=this.Jwthelper.decodeToken(token);
  }

}
