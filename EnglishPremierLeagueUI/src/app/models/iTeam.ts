export interface iTeam{
    logoUrl?: string;
    logo?: string | ArrayBuffer | null;   
    matchesPlayed :number;
    matchesWon :number;
    matchesDrawn :number;
    matchesLost :number;
    points?: number;
    stadiumName?: string;
    teamId?: number;
    teamName : string;
}