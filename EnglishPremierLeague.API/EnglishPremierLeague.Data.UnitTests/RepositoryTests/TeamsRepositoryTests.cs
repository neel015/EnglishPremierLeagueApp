using EnglishPremierLeague.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EnglishPremierLeague.Data.UnitTests.RepositoryTests
{
    public class TeamsRepositoryTests : MockDbContext
    {
        private readonly TeamsRepository _teamsRepository;
        public TeamsRepositoryTests()
        {
            _teamsRepository = new TeamsRepository(EplDbContext);
        }

        [Fact]
        public void Should_Return_Player_With_Team()
        {
            var country = CountriesDataFactory.Initailize();
            var player = PlayersDataFactory.Initialize(country);
            var team = TeamsDataFactory.Initialzie(new List<Domain.Entities.Player> { player });

            var teamData = _teamsRepository.GetTeamWithPlayers(team.TeamId);

            Assert.Equal(team, teamData);
            Assert.Single(team.Players);
            Assert.Equal(player, team.Players.FirstOrDefault());
        }

    }
}
