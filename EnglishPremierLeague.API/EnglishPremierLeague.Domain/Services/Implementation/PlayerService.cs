using EnglishPremierLeague.Domain.Entities;
using EnglishPremierLeague.Domain.Ports.Repositories.Uow;
using EnglishPremierLeague.Domain.Services.Interfaces;
using System.Linq;

namespace EnglishPremierLeague.Domain.Services.Implementation
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _uow;
        public PlayerService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void AddPlayer(Player player)
        {
            var country = _uow.Countries.Find(c => c.CountryName == player.Origin.CountryName).FirstOrDefault();
            var team = _uow.Teams.Find(t => t.TeamName == player.Team.TeamName).FirstOrDefault();
            if (country != null)
                player.Origin = country;
            if (team != null)
                player.Team = team; 
            _uow.Players.Add(player);
            _uow.Complete();
        }
    }
}
