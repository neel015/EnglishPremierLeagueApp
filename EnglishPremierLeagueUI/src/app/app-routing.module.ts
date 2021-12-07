import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddTeamComponent } from './components/addteam/addteam.component';
import { LandingComponent } from './components/landing/landing.component';
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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
