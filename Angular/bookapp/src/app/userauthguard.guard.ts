import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { MsalService } from '@azure/msal-angular';
import { AuthenticationResult } from '@azure/msal-browser';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserauthguardGuard implements CanActivate {

  constructor(private msalService:MsalService,private router:Router)
  {

  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      if(this.msalService.instance.getActiveAccount()!=null)
      {
        return true;
      }
      else
      {
        if (this.router.url === '/') {
          this.msalService.loginPopup().subscribe((response:AuthenticationResult)=>{
            this.msalService.instance.setActiveAccount(response.account);
        })
        }
        return false;
      }
  }
  
}
