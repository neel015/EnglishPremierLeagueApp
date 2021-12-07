import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { iTeam } from 'src/app/models/iTeam';
import { TeamsService } from 'src/app/services/team.service';

@Component({
  selector: 'app-teamsview',
  templateUrl: './teamsview.component.html',
  styleUrls: ['./teamsview.component.css']
})
export class TeamsviewComponent implements OnInit {

  constructor(private teamsService: TeamsService,
    private router: Router) { }
    
  teams: iTeam[] = [];

  ngOnInit(): void {
    this.getAllTeams();
  }

  public getAllTeams() {
    this.teamsService.getAllTeams().subscribe(teams=>{
      this.teams = teams;
      if(this.teams)
        this.teams = this.teams.sort(s=> s.points ?? 0);
    },
    ()=>{
      alert("Something failed");
    })
  }

  async getImage(url: string): Promise<Blob>{
      return await this.teamsService.getTeamLogo(url).toPromise();
  }

  public getTeamDetail(id?: number): void{
    if(id)
      this.router.navigateByUrl(
        `/teamDetail?teamId=${id}`
      );
  }

}
