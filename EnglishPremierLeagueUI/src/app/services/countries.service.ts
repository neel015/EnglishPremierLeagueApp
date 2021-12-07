import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { environment } from "src/environments/environment";
import { endpoints } from "../config/constants/endpointurl";
import { iCountry } from "../models/iCountry";

@Injectable()
export class CountriesService{
    private apiBaseUrl : string = "";
    constructor(private httpClient: HttpClient) {
        this.apiBaseUrl = `${environment.apiBaseUrl}${environment.apiV1Prefix}`;
    }

    public getCountries(): Observable<iCountry[]>{
        return this.httpClient.get<iCountry[]>(`${this.apiBaseUrl}${endpoints.countries}`)
    }
}