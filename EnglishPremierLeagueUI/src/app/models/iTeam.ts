export interface iTeam{
    logoUrl?: string;
    logo: Blob;    
    matchesPlayed :number;
    matchesWon :number;
    matchesDrawn :number;
    matchesLost :number;
    position: number;
    points: number;
    stadiumName?: string;
    teamId: number;
    teamName : string;
}