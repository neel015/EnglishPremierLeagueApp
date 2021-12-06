using EnglishPremierLeague.Blobs.Services;
using EnglishPremierLeague.Domain.Ports.Blobs;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishPremierLeague.Blobs.Configuration
{
    public static class ConfigureService
    {
        public static IServiceCollection AddBlobServices(this IServiceCollection services)
        {
            services.AddScoped<ITeamLogoUploader, TeamLogoUploader>();
            return services;
        }
    }
}
