using EnglishPremierLeague.Domain.Services.Implementation;
using EnglishPremierLeague.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishPremierLeague.Domain.Configuration
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ITeamService, TeamService>()
                    .AddScoped<IPlayerService, PlayerService>();
            return services;
        }
    }
}
