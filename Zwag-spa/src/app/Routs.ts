import {Routes} from "@angular/router"
import { HomeComponent } from './Home/Home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { ListsComponent } from './lists/lists.component';
import { MassegesComponent } from './masseges/masseges.component';
import { AuthGuard } from './_Guards/auth.guard';
import { MembersDetailsComponent } from './members/members-Details/members-Details.component';
import { MemberDetailsResorver } from './_resolvers/members-Details.resolvers';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MembersEditResorver } from './_resolvers/members-edit.resolvers';

export const appRouts:Routes =[

   {path :'',component:HomeComponent},
   {path :'',runGuardsAndResolvers:'always',canActivate:[AuthGuard],
   children:[
   {path :'members',component:MemberListComponent},
   {path :'members/:id',component:MembersDetailsComponent,resolve:{user:MemberDetailsResorver}},
   {path :'lists',component:ListsComponent},
   {path :'masseges',component:MassegesComponent},
   {path :'member/edit',component:MemberEditComponent,resolve:{user:MembersEditResorver}}

],
  },
   {path:'**',redirectTo:'',pathMatch:'full'} 
];
