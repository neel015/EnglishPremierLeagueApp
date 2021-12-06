using EnglishPremierLeague.Data.Repositories;
using EnglishPremierLeague.Data.Uow;
using EnglishPremierLeague.Domain.Ports.Repositories;
using EnglishPremierLeague.Domain.Ports.Repositories.Uow;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishPremierLeague.Data.Configuration
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services)
        {
            services.AddDbContext<EnglishPremierLeagueDbContext>()
                .AddScoped<ICountriesRepository, CountriesRepository>()
                .AddScoped<ITeamsRepository, TeamsRepository>()
                .AddScoped<IPlayersRepository, PlayersRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
