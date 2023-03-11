using Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class ServiceExtensions
    {
        
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    // .WithOrigins("http://localhost:4200")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    );
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration Configuration, string connectionString)
        {
            services.AddDbContext<CarDebateContext>(options =>
                            options.UseSqlServer(
                                Configuration.GetConnectionString(connectionString)//,
                                                                                   //b => b.MigrationsAssembly(nameMigration)
                            ).EnableSensitiveDataLogging()
                        );
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            // var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var key = Encoding.ASCII.GetBytes("this is the secret phrase");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
            //    x.Events = new JwtBearerEvents
            //    {
            //        OnTokenValidated = context =>
            //        {
            //            //    var userService = context.HttpContext.RequestServices.GetRequiredService/*<IUserService>*/();
            //            //    var userId = int.Parse(context.Principal.Identity.Name);
            //            //    var user = userService.GetById(userId);
            //            //    if (user == null)
            //            //    {
            //            //        // return unauthorized if user no longer exists
            //            //        context.Fail("Unauthorized");
            //            //    }
            //            return Task.CompletedTask;
            //        }
            //    };
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });
        }
    }
}
