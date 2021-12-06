using EnglishPremierLeague.Domain.Entities;

namespace EnglishPremierLeague.Domain.Ports.Repositories
{
    public interface ITeamsRepository : IRepository<Team>
    {
        Team GetTeamWithPlayers(int teamId);
    }
}
