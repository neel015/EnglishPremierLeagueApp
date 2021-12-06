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

        public async Task CreateTeam(Team team, byte[] teamLogo)
        {
            //var logoUrl = await _teamLogoUploader.UploadTeamLogo(team, teamLogo);
           // team.LogoUrl = logoUrl;
            _uow.Teams.Add(team);
            _uow.Complete();
        }
    }
}
