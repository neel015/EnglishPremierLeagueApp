using EnglishPremierLeague.Domain.Entities;
using System.Threading.Tasks;

namespace EnglishPremierLeague.Domain.Ports.Blobs
{
    public interface ITeamLogoUploader
    {
        Task<string> UploadTeamLogo(Team team, byte[] logo);
    }
}
