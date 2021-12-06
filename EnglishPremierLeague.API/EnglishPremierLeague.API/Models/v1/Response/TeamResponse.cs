using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPremierLeague.API.Models.v1.Response
{
    public class TeamResponse : TeamsResponse
    {
        public List<PlayerResponse> Players { get; set; }
    }

    public class PlayerResponse
    {
        public int PlayerId { get; set; }
        public int GoalsInCareer { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
    }
}
