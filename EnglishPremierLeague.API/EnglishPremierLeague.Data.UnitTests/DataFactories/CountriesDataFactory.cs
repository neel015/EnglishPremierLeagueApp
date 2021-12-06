using EnglishPremierLeague.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPremierLeague.Data.UnitTests.DataFactories
{
    public class CountriesDataFactory
    {
        private readonly EnglishPremierLeagueDbContext _dbcontext;
        public CountriesDataFactory(EnglishPremierLeagueDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public Country Initailize()
        {
            if(_dbcontext.Countries.Any())
                return _dbcontext.Countries.First();

            var country = new Country
            {
                CountryName = "India"
            };
            _dbcontext.Countries.Add(country);
            _dbcontext.SaveChanges();

            return country;
        }

    }
}
