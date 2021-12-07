using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPremierLeague.API.Models.v1.Response
{
    public class TeamsResponse
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string LogoUrl { get; set; }
        public string StadiumName { get; set; }
        public int Points { get; set; }
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesDrawn { get; set; }
        public int MatchesLost { get; set; }

    }
}
