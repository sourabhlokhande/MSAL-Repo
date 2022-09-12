import { Component } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { AuthenticationResult } from '@azure/msal-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'bookapp';
  loginLinkText:string="Logout";
  username : any = '';
  currentDate : Date = new Date;
  constructor(private msalService:MsalService)
  {
    if(!this.isUserLoggedIn())
    {
      this.loginLinkText="Login";
    }
  }

  login()
  {
    this.msalService.loginPopup().subscribe((response:AuthenticationResult)=>{
        this.msalService.instance.setActiveAccount(response.account);
    })
  }

  logout()
  {
    this.msalService.logout();
  }
  isUserLoggedIn():boolean
  {
    if(this.msalService.instance.getActiveAccount()!=null)
    {
      
      this.username = this.msalService.instance.getActiveAccount()?.name;
      return true;
    }
    return false;
  }

}
