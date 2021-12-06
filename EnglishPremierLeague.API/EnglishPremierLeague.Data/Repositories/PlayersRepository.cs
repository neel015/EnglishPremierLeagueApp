
using EnglishPremierLeague.Domain.Entities;
using EnglishPremierLeague.Domain.Ports.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnglishPremierLeague.Data.Repositories
{
    public class PlayersRepository : Repository<Player>, IPlayersRepository
    {
        public PlayersRepository(EnglishPremierLeagueDbContext dbContext) : base(dbContext)
        {
        }
    }
}
