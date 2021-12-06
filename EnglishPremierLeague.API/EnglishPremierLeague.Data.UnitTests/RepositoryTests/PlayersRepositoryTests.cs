using EnglishPremierLeague.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnglishPremierLeague.Data.UnitTests.RepositoryTests
{
    public class PlayersRepositoryTests : MockDbContext
    {
        private readonly PlayersRepository _playersRepository;
        public PlayersRepositoryTests()
        {
            _playersRepository = new PlayersRepository(EplDbContext);
        }

        [Fact]
        public void Should_return_all_players()
        {
            var country = CountriesDataFactory.Initailize();
            var playerToBeCompared = PlayersDataFactory.Initialize(country);

            var playersData = _playersRepository.GetAll();

            Assert.Contains(playerToBeCompared, playersData);
        }

        [Fact]
        public void Should_Return_Specific_player()
        {
            var country = CountriesDataFactory.Initailize();
            var playerToBeCompared = PlayersDataFactory.Initialize(country);

            var player = _playersRepository.Get(playerToBeCompared.PlayerId);

            Assert.Equal(player, playerToBeCompared);
        }


    }
}
