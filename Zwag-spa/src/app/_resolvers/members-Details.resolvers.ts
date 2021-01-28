
import { UserService } from './../Services/User.service';

import { Injectable } from '@angular/core';
import { User } from '../_Models/User';
import { Router,Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../Services/Alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';



@Injectable()

export class MemberDetailsResorver implements Resolve<User>{
    constructor(private userservice:UserService,private router:Router,private alert:AlertifyService){}
    resolve(route:ActivatedRouteSnapshot):Observable<User>{
        return this.userservice.getuser(route.params['id']).pipe(
           catchError(error=>{this.alert.Error("es gibt eine Problem");
           this.router.navigate(['/members']);
           return of(null);
        
        })

        )
    }
}