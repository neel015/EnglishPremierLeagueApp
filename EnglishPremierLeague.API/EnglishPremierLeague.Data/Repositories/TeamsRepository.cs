using EnglishPremierLeague.Domain.Entities;
using EnglishPremierLeague.Domain.Ports.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EnglishPremierLeague.Data.Repositories
{
    public class TeamsRepository : Repository<Team>, ITeamsRepository
    {
        private readonly EnglishPremierLeagueDbContext _eplDbContext;
        public TeamsRepository(EnglishPremierLeagueDbContext eplDbContext) : base(eplDbContext)
        {
            _eplDbContext = eplDbContext;
        }

        public Team GetTeamWithPlayers(int teamId)
        {
            var team = _eplDbContext.Teams
                .Include(team => team.Players)
                .ThenInclude(p=> p.Origin)
                .FirstOrDefault(team => team.TeamId == teamId);
            return team;
        }
    }
}
