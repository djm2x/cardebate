using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Repository.Shared;

namespace mvc
{
    public class Startup
    {
        // public Startup(IConfiguration configuration)
        // {
        //     Configuration = configuration;
        // }

        // public IConfiguration Configuration { get; }
        private readonly ILogger _logger;
        public Startup(IHostingEnvironment env, ILogger<Startup> logger)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
            _logger = logger;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
            services.ConfigureCors();
            services.AddSignalR();

            services.ConfigureIISIntegration();
            services.ConfigureDbContext(Configuration, "smart");
            services.ConfigureAuthentication(Configuration);

            services.AddNodeServices();
            // services.AddSpaPrerenderer();
            services.AddHttpContextAccessor();
            services.AddTransient<UnitOfWork>();
            _logger.LogInformation("Added UnitOfWork to services");
            // services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // app.UseSpa(spa =>
                // {
                //     spa.Options.SourcePath = env.ContentRootPath;
                //     // if (env.IsDevelopment())
                //     spa.UseAngularCliServer(npmScript: "i");
                // });
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // app.UseSignalR(routes =>
            // {
            //     routes.MapHub<Notification>("/notify");
            // });
            app.Use(async (context, next) =>
            {
                IHeaderDictionary headers = context.Request.Headers;
                // var auth = headers.HeaderAuthorization();
                // var type = headers.HeaderContentType();

                _logger.LogInformation("costum mw 1 to the controller");
                await next();
            });

            app.UseCors("CorsPolicy");
            app.UseMiddleware<ErrorHandler>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            // app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

        }
    }
}
