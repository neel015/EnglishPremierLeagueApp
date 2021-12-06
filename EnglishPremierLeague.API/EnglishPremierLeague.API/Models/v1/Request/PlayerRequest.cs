using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPremierLeague.API.Models.v1.Request
{
    public class PlayerRequest
    {
        public int GoalsInCareer { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string CountryName { get; set; }
    }
}
