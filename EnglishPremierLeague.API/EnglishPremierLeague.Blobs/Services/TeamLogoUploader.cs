using EnglishPremierLeague.Domain.Entities;
using EnglishPremierLeague.Domain.Ports.Blobs;
using System;
using System.Threading.Tasks;

namespace EnglishPremierLeague.Blobs.Services
{
    public class TeamLogoUploader : ITeamLogoUploader
    {
        public Task<string> UploadTeamLogo(Team team, byte[] logo)
        {
            throw new NotImplementedException();
        }
    }
}
