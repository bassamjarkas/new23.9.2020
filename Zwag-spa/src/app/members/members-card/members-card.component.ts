import { Component, OnInit, Input } from '@angular/core';
import { User  } from "../../_Models/User";
//import { faUser } from '@fortawesome/free-solid-svg-icons';
//import { faSuse } from '@fortawesome/free-brands-svg-icons';

@Component({
  selector: 'app-members-card',
  templateUrl: './members-card.component.html',
  styleUrls: ['./members-card.component.css']
})
export class MembersCardComponent implements OnInit {
  @Input() user:User;
//fauser=faSuse;
  constructor() { }

  ngOnInit(): void {
  }

}
