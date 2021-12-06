import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddTeamComponent } from './components/add-team/add-team.component';
import { LandingComponent } from './components/landing/landing.component';
import { NoAccessComponent } from './components/no-access/no-access.component';
import { TeamdetailComponent } from './components/teamdetail/teamdetail.component';

const routes: Routes = [
  {
    path: "add-team",
    component: AddTeamComponent
  },
  {
    path: "landing",
    component: LandingComponent    
  },
  {
    path: "teamDetail",
    component: TeamdetailComponent
  },
  {
    path: "no-access",
    component: NoAccessComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
