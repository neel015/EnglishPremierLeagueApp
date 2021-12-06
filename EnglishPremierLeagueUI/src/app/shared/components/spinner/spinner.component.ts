import { Component, OnInit } from '@angular/core';
import { SpinnerService } from '../../services/spinner.service';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.css']
})
export class SpinnerComponent implements OnInit {

  public showSpinner: boolean = false;
  constructor(private spinnerService: SpinnerService) { }

  ngOnInit(): void {
    this.setSpinnerState();
  }

  setSpinnerState() {
    this.spinnerService.getSpinnerState().subscribe(showSpinner=>{
      this.showSpinner = showSpinner;
    })
  }

}
