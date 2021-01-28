import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertifyService } from '../Services/Alertify.service';

import {AuthServiceService } from "../Services/AuthService.service";
@Component({
  selector: 'app-Nave',
  templateUrl: './Nave.component.html',
  styleUrls: ['./Nave.component.scss']
})
export class NaveComponent implements OnInit {
  model1:any ={}

  constructor(public authservice:AuthServiceService,private Alertify:AlertifyService,private router:Router) { }

  ngOnInit() {
  }

  login(){
  this.authservice.login(this.model1).subscribe(
    next=>{this.Alertify.sucsses("Sucsess")},
    error=>{this.Alertify.Error(error)},
    ()=>this.router.navigate(['/members'])
  );



  }
  logeddin(){
    return this.authservice.loggedIn();
  }
  loggedout(){
    localStorage.removeItem("token");
    this.Alertify.Message("تم تسجيل الخروج");
    this.router.navigate(['/home']);
  }


}


