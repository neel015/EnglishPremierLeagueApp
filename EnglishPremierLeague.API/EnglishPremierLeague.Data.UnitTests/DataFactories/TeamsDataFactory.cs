using EnglishPremierLeague.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPremierLeague.Data.UnitTests.DataFactories
{
    public class TeamsDataFactory 
    {
        private readonly EnglishPremierLeagueDbContext _dbcontext;
        public TeamsDataFactory(EnglishPremierLeagueDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public Team Initialzie(List<Player> players)
        {
            if(_dbcontext.Teams.Any())
                return _dbcontext.Teams.First();

            var team = new Team
            {
                TeamName = "Test Team",
                LogoUrl = "https://test.com/logo.png",
                Players = players,
                StadiumName = "Test Stadium"
            };
            _dbcontext.Teams.Add(team);
            _dbcontext.SaveChanges();
            return team;

        }
    }
}
