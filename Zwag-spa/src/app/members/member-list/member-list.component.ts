import { Component, OnInit } from '@angular/core';
import  {User} from '../../_Models/User';
import { UserService } from '../../Services/User.service';
import { AlertifyService } from '../../Services/Alertify.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.scss']
})
export class MemberListComponent implements OnInit {
users:User[];
  constructor(private userService:UserService,private alert:AlertifyService) { }

  ngOnInit() {
   this.Loadusers();
  }

  Loadusers(){
    this.userService.getUsers().subscribe(
      (users:User[])=>{this.users=users;},error=>this.alert.Error(error)
    );
  }

}
