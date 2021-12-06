import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { SpinnerService } from './services/spinner.service';
import { NavbarComponent } from './components/navbar/navbar.component';



@NgModule({
  declarations: [
    SpinnerComponent,
    NavbarComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    NavbarComponent,
    SpinnerComponent
  ],
  providers:[
    SpinnerService
  ]
})
export class SharedModule { }
