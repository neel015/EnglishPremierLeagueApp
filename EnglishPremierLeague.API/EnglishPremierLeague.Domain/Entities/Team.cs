using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishPremierLeague.Domain.Entities
{
    public class Team
    {
        public Coach Coach { get; set; }
        [NotMapped]
        public string Logo { get; set; }
        public string LogoUrl { get; set; }
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesDrawn { get; set; }
        public int MatchesLost { get; set; }
        public int Points { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();        
        public string StadiumName { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
           
    }
}
