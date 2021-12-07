import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { endpoints } from "../config/constants/endpointurl";
import { iTeam } from "../models/iTeam";
import { iTeamDetail } from "../models/iTeamDetail";

@Injectable()
export class TeamsService{
    private apiBaseUrl : string = "";
    constructor(private httpClient: HttpClient) {
        this.apiBaseUrl = `${environment.apiBaseUrl}${environment.apiV1Prefix}`;
    }
    public getAllTeams(): Observable<iTeam[]>{
        return this.httpClient.get<iTeam[]>(`${this.apiBaseUrl}${endpoints.teams}`);
    }

    public getTeamById(teamId: number): Observable<iTeamDetail>{
        let url = `${this.apiBaseUrl}${endpoints.teamDetail}`;
        url = url.replace("{teamId}", teamId.toString());
        return this.httpClient.get<iTeamDetail>(url);
    }

    public getTeamLogo(url: string): Observable<Blob>{
        return this.httpClient.get(url, {responseType: "blob"});
    }

    public deleteTeam(teamId: number): Observable<any>{
        let url = `${this.apiBaseUrl}${endpoints.teamDetail}`;
        url = url.replace("{teamId}", teamId.toString());
        return this.httpClient.delete(url);
    }

    public addTeam(team: iTeamDetail): Observable<any>{
        return this.httpClient.post(`${this.apiBaseUrl}${endpoints.teams}`,team);
    }
}