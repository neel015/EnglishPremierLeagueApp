using EnglishPremierLeague.API.Models;
using EnglishPremierLeague.API.Models.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPremierLeague.API.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services, IConfiguration configuration)
        {
            var authUrl = $"{configuration["AzureAd:Instance"]}common/oauth2/v2.0/authorize";
            var tokenUrl = $"{configuration["AzureAd:Instance"]}common/oauth2/v2.0/token";
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EnglishPremierLeague.API", Version = "v1" });
                //c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                //{
                //    Type = SecuritySchemeType.OAuth2,
                //    Flows = new OpenApiOAuthFlows
                //    {
                //        AuthorizationCode = new OpenApiOAuthFlow
                //        {
                //            AuthorizationUrl = new Uri(authUrl, UriKind.Absolute),
                //            Scopes = new Dictionary<string, string>
                //            {
                //                { $"{configuration["AzureAd:ClientId"]}/{configuration["AzureAd:Scope"]}", "Access EPL API" }
                //            },
                //            TokenUrl = new Uri(tokenUrl, UriKind.Absolute)
                //        }
                //    }
                //});
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "oauth2",
                //            },
                //        }, new List<string>()
                //    }
                //});
            });

            return services;
        }

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("default", builder =>
                {
                    builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });
            return services;
        }

        public static IServiceCollection AddApiVersions(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(config => {
                config.GroupNameFormat = "'v'VVV";
                config.SubstituteApiVersionInUrl = true;
            });
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            return services;
        }

        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ModelMapperV1));
            return services;
        }
    }
}
