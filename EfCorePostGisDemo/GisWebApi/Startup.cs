using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GisWebApi.GisModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GisWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            CurrentEnv = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment CurrentEnv { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "PostGis 示範 API";
                    document.Info.Description = "A simple ASP.NET Core web API to demo PostGis functionality";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Isak Pao",
                        Email = string.Empty,
                        Url = "http://linktr.ee/windperson"
                    };
                };
            });

            services.AddDbContext<DemoGisDbContext>(options =>
            {
                options
                    .UseNpgsql(Configuration.GetConnectionString("DemoGisDb"), builder => builder.UseNetTopologySuite())
                    .UseSnakeCaseNamingConvention()
                    .EnableDetailedErrors(CurrentEnv.IsDevelopment())
                    .EnableSensitiveDataLogging(CurrentEnv.IsDevelopment())
                    .UseLazyLoadingProxies();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}