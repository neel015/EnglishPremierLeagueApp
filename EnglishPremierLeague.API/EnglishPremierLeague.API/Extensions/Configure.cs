using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace EnglishPremierLeague.API.Extensions
{
    public static class Configure
    {
        public static void UseSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.DocExpansion(DocExpansion.None);
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EnglishPremierLeague.API v1");
                    c.OAuthUsePkce();
                });
            }
        }

        public static void UseCors(this IApplicationBuilder app, IConfiguration configuration)
        {
            var section = configuration.GetSection(@"Allowed-Origins:Origins");
            var allowedOrigins = section.Get<string[]>();
            app.UseCors(builder =>
            {
                builder.SetIsOriginAllowedToAllowWildcardSubdomains()
                    .WithOrigins(allowedOrigins);
                builder.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });

        }

    }
}
