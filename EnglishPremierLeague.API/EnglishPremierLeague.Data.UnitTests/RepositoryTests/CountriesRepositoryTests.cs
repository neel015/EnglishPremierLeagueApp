using EnglishPremierLeague.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnglishPremierLeague.Data.UnitTests.RepositoryTests
{
    public class CountriesRepositoryTests : MockDbContext
    {
        private readonly CountriesRepository _countriesRepository;
        public CountriesRepositoryTests()
        {
            _countriesRepository = new CountriesRepository(EplDbContext);
        }

        [Fact]
        public void Should_return_all_countries()
        {
            var countryToBeCompared = CountriesDataFactory.Initailize();

            var countryData = _countriesRepository.GetAll();

            Assert.Contains(countryToBeCompared, countryData);
        }

        [Fact]
        public void Should_Return_Specific_country()
        {
            var countryToBeCompared = CountriesDataFactory.Initailize();

            var countryData = _countriesRepository.Get(countryToBeCompared.CountryId);

            Assert.Equal(countryToBeCompared, countryData);
        }

    }
}
