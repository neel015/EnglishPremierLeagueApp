import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AddTeamComponent } from './components/add-team/add-team.component';
import { LandingComponent } from './components/landing/landing.component';
import { TeamsviewComponent } from './components/teamsview/teamsview.component';
import { TeamsService } from './services/team.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TeamdetailComponent } from './components/teamdetail/teamdetail.component';
import { SharedModule } from './shared/shared.module';
import { HttpRequestInterceptor } from './interceptors/http-request.interceptor';
import { MsalBroadcastService, MsalGuard, MsalInterceptor, MsalService, MSAL_GUARD_CONFIG, MSAL_INSTANCE, MSAL_INTERCEPTOR_CONFIG } from '@azure/msal-angular';
import { MSALInstanceFactory } from './config/auth/msalInstanceFactory';
import { MSALGuardConfigFactory } from './config/auth/msalGuardConfigFactory';
import { MSALInterceptorConfigFactory } from './config/auth/msalInterceptorConfigFactory';
import { NoAccessComponent } from './components/no-access/no-access.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AccordionModule } from 'ngx-bootstrap/accordion';
@NgModule({
  declarations: [
    AppComponent,
    LandingComponent,
    TeamsviewComponent,
    AddTeamComponent,
    TeamdetailComponent,
    NoAccessComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AccordionModule.forRoot(),
    ReactiveFormsModule
  ],
  providers: [
    TeamsService,
    { 
      provide: HTTP_INTERCEPTORS, 
      useClass: HttpRequestInterceptor,
       multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true
    },
    {
      provide: MSAL_INSTANCE,
      useFactory: MSALInstanceFactory
    },
    {
      provide: MSAL_GUARD_CONFIG,
      useFactory: MSALGuardConfigFactory
    },
    {
      provide: MSAL_INTERCEPTOR_CONFIG,
      useFactory: MSALInterceptorConfigFactory
    },
    MsalService,
    MsalGuard,
    MsalBroadcastService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
