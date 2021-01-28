import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AlertifyService } from '../Services/Alertify.service';
import { AuthServiceService } from '../Services/AuthService.service';

@Component({
  selector: 'app-Register',
  templateUrl: './Register.component.html',
  styleUrls: ['./Register.component.scss']
})
export class RegisterComponent implements OnInit {
 @Input() Valueregister:any;
 @Output() cancelregister=new EventEmitter();
  model:any={};

  constructor(private Autservice:AuthServiceService,private Alertify:AlertifyService) { }

  ngOnInit() {
  }
  register(){

this.Autservice.register(this.model).subscribe(
()=>{ this.Alertify.sucsses("تم التسجيل بنجاح");},
error=>{this.Alertify.Error(error);}

);


  }

  cancel(){
  this.cancelregister.emit(false);
}



}
