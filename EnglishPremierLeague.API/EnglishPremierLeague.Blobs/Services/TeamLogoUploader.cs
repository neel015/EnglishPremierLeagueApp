using Azure.Storage.Blobs;
using EnglishPremierLeague.Domain.Entities;
using EnglishPremierLeague.Domain.Ports.Blobs;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EnglishPremierLeague.Blobs.Services
{
    public class TeamLogoUploader : ITeamLogoUploader
    {
        private readonly BlobServiceClient _blobServiceClient;
        public TeamLogoUploader(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
        public string UploadTeamLogo(Team team)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("logos");
            var blobRef = containerClient.GetBlobClient(team.TeamName);
            if(blobRef.Exists())
                return blobRef.Uri.ToString();

            var startIndex = team.Logo.IndexOf("base64") + 7;
            var logoString = team.Logo.Substring(startIndex, team.Logo.Length - startIndex);
            var bytes = Convert.FromBase64String(logoString);
            using (var stream = new MemoryStream(bytes))
            {
                blobRef.Upload(stream);
            }

            return blobRef.Uri.ToString();
        }
    }
}
