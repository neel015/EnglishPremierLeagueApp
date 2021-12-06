using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPremierLeague.Domain.Ports.Repositories.Uow
{
    public interface IUnitOfWork
    {
        ICountriesRepository Countries {get;}
        IPlayersRepository Players { get; }
        ITeamsRepository Teams { get; }

        int Complete();
    }
}
