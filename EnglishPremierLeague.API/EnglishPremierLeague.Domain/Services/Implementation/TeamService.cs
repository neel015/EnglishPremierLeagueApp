using EnglishPremierLeague.Domain.Entities;
using EnglishPremierLeague.Domain.Ports.Blobs;
using EnglishPremierLeague.Domain.Ports.Repositories.Uow;
using EnglishPremierLeague.Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace EnglishPremierLeague.Domain.Services.Implementation
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _uow;
        private readonly ITeamLogoUploader _teamLogoUploader;
        public TeamService(ITeamLogoUploader teamLogoUploader,
            IUnitOfWork uow)
        {
            _teamLogoUploader = teamLogoUploader;
            _uow = uow;
        }

        public void CreateTeam(Team team)
        {
            var logoUrl = _teamLogoUploader.UploadTeamLogo(team);
            team.LogoUrl = logoUrl;
            team.Points = team.MatchesWon * 3 + team.MatchesDrawn * 1;
            _uow.Teams.Add(team);
            _uow.Complete();
        }

        public void DeleteTeam(int teamId)
        {
            var players = _uow.Players.Find(p => p.TeamId == teamId);
            _uow.Players.RemoveRange(players);
            var team = _uow.Teams.Get(teamId);
            _uow.Teams.Remove(team);
            _uow.Complete();
        }
    }
}
