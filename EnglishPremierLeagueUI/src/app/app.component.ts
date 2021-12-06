import { Component } from '@angular/core';
import { Router } from '@angular/router';
import {MsalService } from '@azure/msal-angular';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'EnglishPremierLeagueUI';
  public userHasLoggedIn: boolean = false;
  constructor(
    private authService: MsalService,
    private router: Router) {
  }

  ngOnInit(){   
    this.doAuth();
  }

  doAuth() {
    this.authService.handleRedirectObservable()
    .subscribe(()=>{
      let accounts = this.authService.instance.getAllAccounts();
      if ((!accounts) || (accounts.length == 0)){
        this.authService.loginRedirect();
      }        
      else{
        this.userHasLoggedIn = true;
        this.router.navigateByUrl("/landing");
      }        
    },
    (err)=>{
      console.error(err);
    })
  }
}
