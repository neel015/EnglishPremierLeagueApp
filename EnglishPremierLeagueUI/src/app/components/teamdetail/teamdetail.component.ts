import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { iTeamDetail } from 'src/app/models/iTeamDetail';
import { TeamsService } from 'src/app/services/team.service';

@Component({
  selector: 'app-teamdetail',
  templateUrl: './teamdetail.component.html',
  styleUrls: ['./teamdetail.component.css']
})
export class TeamdetailComponent implements OnInit {

  private teamId: number = 0;
  public teamDetails!: iTeamDetail;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private teamService: TeamsService) {
    route.queryParams.subscribe((params) => {
      this.teamId = params["teamId"];
    });
   }

  ngOnInit(): void {
    this.getTeamDetail();
  }

  private getTeamDetail() {
     this.teamService.getTeamById(this.teamId).subscribe(team=>{
      this.teamDetails = team;
     },
     ()=>{
       alert("Didnt work");
     })
  }

  deleteTeam(){
    if(!this.teamDetails.teamId)
      return;
    this.teamService.deleteTeam(this.teamDetails.teamId)
    .subscribe(()=>{
      this.router.navigateByUrl("\landing");
    },()=>{
      alert("Something failed");
    })
  }
}
