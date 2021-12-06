import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-team',
  templateUrl: './add-team.component.html',
  styleUrls: ['./add-team.component.css']
})
export class AddTeamComponent implements OnInit {

  public teamForm!: FormGroup;
  public playersFormArray!: FormArray;
  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.initializeForm();
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
      players: this.formBuilder.array([this.getPlayerFormControl()])
    })
  }

  private getPlayerFormControl(): FormGroup {
    return this.formBuilder.group({
      playerName: ['', Validators.required],
      country: [''],
      goalsScored: ['', [Validators.required, Validators.pattern("^[0-9]*$")]]
    })
  }

  public addPlayerFormControl(){
    this.playersFormArray = this.teamForm.get('players') as FormArray;
    this.playersFormArray.push(this.getPlayerFormControl());
  } 

  public get f(){
    return this.teamForm.controls;
  }

  addTeam(){

  }

}
