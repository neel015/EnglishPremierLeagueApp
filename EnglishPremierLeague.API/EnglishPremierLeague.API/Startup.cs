using EnglishPremierLeague.API.Extensions;
using EnglishPremierLeague.Blobs.Configuration;
using EnglishPremierLeague.Data.Configuration;
using EnglishPremierLeague.Domain.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;

namespace EnglishPremierLeague.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMicrosoftIdentityWebApiAuthentication(Configuration);

            services.AddControllers();

            services.AddSwaggerService(Configuration)
                    .AddCorsPolicy()
                    .AddApiVersions()
                    .AddAutoMapperProfiles()
                    .AddDomainServices()
                    .AddDataDependencies(Configuration)
                    .AddBlobServices()
                    .AddAzureClients(builder =>
                    {
                        builder.AddBlobServiceClient(Configuration.GetConnectionString("Storage"));
                    });
                    

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/error-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseCors(Configuration);

            app.UseHttpsRedirection();

            app.UseSwagger(env);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
