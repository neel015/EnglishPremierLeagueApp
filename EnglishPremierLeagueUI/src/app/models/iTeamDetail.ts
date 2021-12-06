import { iPlayer } from "./iPlayer";
import { iTeam } from "./iTeam";

export interface iTeamDetail extends iTeam{
    players: iPlayer[]
}