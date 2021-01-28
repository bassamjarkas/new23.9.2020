import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthServiceService } from '../Services/AuthService.service';


@Component({
  selector: 'app-Home',
  templateUrl: './Home.component.html',
  styleUrls: ['./Home.component.scss']
})
export class HomeComponent implements OnInit {
registermode:boolean=false;
values:any;
  constructor(private http:HttpClient,private auth:AuthServiceService,private rout:Router) { }

  ngOnInit() {

   if (this.auth.loggedIn){
     this.rout.navigate(['/members']);
   }
  }

  registertoggel(){
    this.registermode=! this.registermode;
  }
  getvalue(){

    this.http.get('http://localhost:5000/api/values').subscribe(
    response=>{this.values=response;},
    error=>{console.log("error")}

   );

   }

   cancelregister(mode:boolean){
     this.registermode=mode;
   }



}
