using EnglishPremierLeague.Data.UnitTests.DataFactories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Data.Common;

namespace EnglishPremierLeague.Data.UnitTests
{
    public class MockDbContext :IDisposable
    {
        private readonly DbConnection _dbConnection;
        protected EnglishPremierLeagueDbContext EplDbContext { get; }
        protected CountriesDataFactory CountriesDataFactory { get; }
        protected PlayersDataFactory PlayersDataFactory { get; }
        protected TeamsDataFactory TeamsDataFactory { get; }

        public MockDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<EnglishPremierLeagueDbContext>()
                .UseSqlite(CreateInMemoryDatabase())
                .Options;
            _dbConnection = RelationalOptionsExtension.Extract(dbContextOptions).Connection;

            EplDbContext = new EnglishPremierLeagueDbContext(dbContextOptions);

            EplDbContext.Database.EnsureCreated();

            CountriesDataFactory = new CountriesDataFactory(EplDbContext);
            PlayersDataFactory = new PlayersDataFactory(EplDbContext);
            TeamsDataFactory = new TeamsDataFactory(EplDbContext);
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
        }

        public void Dispose()
        {
            _dbConnection.Dispose();
        }
    }
}
