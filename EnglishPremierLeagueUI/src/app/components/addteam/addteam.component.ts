import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { iCountry } from 'src/app/models/iCountry';
import { iPlayer } from 'src/app/models/iPlayer';
import { iTeamDetail } from 'src/app/models/iTeamDetail';
import { CountriesService } from 'src/app/services/countries.service';
import { TeamsService } from 'src/app/services/team.service';

@Component({
  selector: 'app-add-team',
  templateUrl: './addteam.component.html',
  styleUrls: ['./addteam.component.css']
})
export class AddTeamComponent implements OnInit {

  public teamForm!: FormGroup;
  private playersFormArray!: FormArray;
  public countries: iCountry[] = [];
  private logoContent!: string | ArrayBuffer | null;
  constructor(private formBuilder: FormBuilder,
    private countriesService: CountriesService,
    private router: Router,
    private teamsService: TeamsService) { }

  ngOnInit(): void {
    this.initializeForm();
    this.getCountries();
  }

  getCountries() {
    this.countriesService.getCountries()
    .subscribe(countries=>{
      this.countries = countries;
    },()=>{
      alert("Some error occured");
    })
  }

  private initializeForm() {
    this.teamForm = this.formBuilder.group({
      teamName: ['', Validators.required],
      stadium: ['', Validators.required],
      position: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      played:['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      won:['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      lost:['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      drawn:['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      logo: [null],
      players: this.formBuilder.array([this.getPlayerFormControl()])
    })
  }

  private getPlayerFormControl(): FormGroup {
    return this.formBuilder.group({
      playerName: ['', Validators.required],
      country: [''],
      goalsScored: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      age: ['', Validators.required]
    })
  }

  public addPlayerFormControl(){
    this.playersFormArray = this.playersArray;
    this.playersFormArray.push(this.getPlayerFormControl());
  } 

  public removePlayerFormControl(index: number){
    this.playersFormArray = this.playersArray;
    this.playersFormArray.removeAt(index);
  }

  public get tc(){
    return this.teamForm.controls;
  }

  public get playersArray(): FormArray{
    return this.teamForm.get('players') as FormArray;
  }

  public getPlayerFormGroup(formGroup: AbstractControl): FormGroup{
    return formGroup as FormGroup;
  }

  public addTeam(): void {
    var teamDetail : iTeamDetail = {
      teamName:  this.teamForm.get('teamName')?.value,
      stadiumName: this.teamForm.get('stadium')?.value,
      matchesDrawn: this.teamForm.get('drawn')?.value,
      matchesWon: this.teamForm.get('won')?.value,
      matchesPlayed : this.teamForm.get('played')?.value,
      matchesLost: this.teamForm.get('lost')?.value,
      logo: this.logoContent,
      players: []
    }
    for(let playerControl of this.playersArray.controls){
      let playerName = playerControl.get('playerName')?.value
      if(!playerName)
        continue;
      let player : iPlayer= {
        name : playerName,
        countryOfOrigin: playerControl.get('country')?.value,
        goalsInCareer: playerControl.get('goalsScored')?.value,
        age: playerControl.get('goalsScored')?.value
      }
      teamDetail.players.push(player);
    }
    this.saveTeamDetailInBackend(teamDetail);
  }

  public logoUploaded(event: any): void {
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
       this.logoContent = reader.result;
    };
  }

  private saveTeamDetailInBackend(teamDetail: iTeamDetail) : void{
    this.teamsService.addTeam(teamDetail)
    .subscribe(()=>{
      this.router.navigateByUrl("/landing");
    },()=>{

    })
  }

}
