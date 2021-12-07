using EnglishPremierLeague.Domain.Entities;
using System.Threading.Tasks;

namespace EnglishPremierLeague.Domain.Ports.Blobs
{
    public interface ITeamLogoUploader
    {
        string UploadTeamLogo(Team team);
    }
}
