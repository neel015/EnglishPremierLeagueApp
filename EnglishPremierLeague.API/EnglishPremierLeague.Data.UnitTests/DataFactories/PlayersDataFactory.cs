using EnglishPremierLeague.Domain.Entities;
using System.Linq;

namespace EnglishPremierLeague.Data.UnitTests.DataFactories
{
    public class PlayersDataFactory
    {
        private readonly EnglishPremierLeagueDbContext _dbcontext;
        public PlayersDataFactory(EnglishPremierLeagueDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public Player Initialize(Country country)
        {
            if(_dbcontext.Players.Any())
                return _dbcontext.Players.First();

            var player = new Player
            {
                Name = "John Smith",
                Age = 26,
                GoalsInCareer = 22,
                Origin = country,
                CountryId = country.CountryId
            };

            _dbcontext.Players.Add(player);
            _dbcontext.SaveChanges();
            return player;
        }

    }
}
