using EnglishPremierLeague.Domain.Ports.Repositories;
using EnglishPremierLeague.Domain.Ports.Repositories.Uow;
using System;
using System.Threading.Tasks;

namespace EnglishPremierLeague.Data.Uow
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EnglishPremierLeagueDbContext _eplDbContext;
        public ICountriesRepository Countries { get; private set; }
        public IPlayersRepository Players { get; private set; }
        public ITeamsRepository Teams { get; private set; }
        public UnitOfWork(EnglishPremierLeagueDbContext eplDbContext,
            ICountriesRepository countriesRepository,
            IPlayersRepository playersRepository,
            ITeamsRepository teamsRepository)
        {
            _eplDbContext = eplDbContext;
            Countries = countriesRepository;
            Players = playersRepository;
            Teams = teamsRepository;
        }

        public int Complete()
        {
            return _eplDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _eplDbContext.Dispose();
        }
    }
}
