import { MembersEditResorver } from './_resolvers/members-edit.resolvers';
import { MemberDetailsResorver } from './_resolvers/members-Details.resolvers';
import { MembersDetailsComponent } from './members/members-Details/members-Details.component';

import { UserService } from './Services/User.service';
import { JwtModule } from '@auth0/angular-jwt';
import { AlertifyService } from './Services/Alertify.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';

import { NaveComponent } from './Nave/Nave.component';
import { FormsModule } from "@angular/forms";
import { AuthServiceService } from "./Services/AuthService.service";
import { HomeComponent } from './Home/Home.component';
import { RegisterComponent } from './Register/Register.component';
import { ErrorInterceptorProvidor } from './Services/error.Interceptor';
import { MemberListComponent } from './members/member-list/member-list.component';
import { ListsComponent } from './lists/lists.component';
import { MassegesComponent } from './masseges/masseges.component';
import { RouterModule } from '@angular/router';
import { appRouts } from './Routs';
import { AuthGuard } from './_Guards/auth.guard';
import { MembersCardComponent } from './members/members-card/members-card.component';

import { MemberEditComponent } from './members/member-edit/member-edit.component';


export function tokenGetter() {
  return localStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,

      NaveComponent,
      HomeComponent,
      RegisterComponent,
      MemberListComponent,
      ListsComponent,
      MassegesComponent,
      MembersCardComponent,
      MembersDetailsComponent,
      MemberEditComponent,


   ],
  imports: [
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,

        allowedDomains: ["localhost:5000"],
        disallowedRoutes: ["localhost:5000/api/auth"],
      },
    }),

  BrowserModule,
  HttpClientModule,
  FormsModule,
  BsDropdownModule.forRoot(),
  RouterModule.forRoot(appRouts),
  TabsModule.forRoot(),


  ],
  providers: [AuthServiceService,ErrorInterceptorProvidor,AlertifyService,AuthGuard,UserService,MemberDetailsResorver,MembersEditResorver],

  bootstrap: [AppComponent]
})
export class AppModule { }
