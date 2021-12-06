import { Component, OnInit } from '@angular/core';
import { MsalService } from '@azure/msal-angular';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  public userHasLoggedIn: boolean = false;
  public userName: string | undefined = "";
  constructor(private authService: MsalService) { }

  ngOnInit(): void {
    let accounts = this.authService.instance.getAllAccounts()
    this.userHasLoggedIn = (accounts && accounts.length > 0);
    if(this.userHasLoggedIn)
      this.userName = accounts[0].name;
  }

  public logout(){
    this.authService.logout();
  }

}
