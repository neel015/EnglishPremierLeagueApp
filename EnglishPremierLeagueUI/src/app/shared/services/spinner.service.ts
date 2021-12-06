import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";

@Injectable()
export class SpinnerService{
    private spinnerShowHideSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
    showSpinner(){
        this.spinnerShowHideSubject.next(true);
    }
    hideSpinner(){
        this.spinnerShowHideSubject.next(false);
    }
    getSpinnerState(): Observable<boolean>{
       return this.spinnerShowHideSubject.asObservable();
    }
}