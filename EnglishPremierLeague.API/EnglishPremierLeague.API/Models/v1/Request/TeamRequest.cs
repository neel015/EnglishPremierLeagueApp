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
        public IFormFile Logo { get; set; }
    }
}
