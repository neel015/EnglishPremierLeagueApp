using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPremierLeague.API.Models.v1.Request
{
    public class TeamRequest
    {
        public string TeamName { get; set; }
        public string StadiumName { get; set; }
        public string Logo { get; set; }
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesDrawn { get; set; }
        public int MatchesLost { get; set; }
        public List<PlayerRequest> Players { get; set; }
    }
}
