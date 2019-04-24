using BlackJackDataAccess;
using BlackJackDataAccess.Domain;
using BlackJackDataAccess.Repositories;
using BlackJackEntities.Entities;
using BlackJackServices;
using BlackJackServices.Services.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Text;

namespace BlackJack
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
              .Build();

      services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetSection("ConnectionStrings:DefaultConnection").Value));
      services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
      services.Configure<AuthOptions>(Configuration.GetSection("AuthOptions"));

      services.Service();

      //services.EfRepository();
      services.DapperRepository();

      services.AddMemoryCache();
      services.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());

      var appSettingsSection = Configuration.GetSection("AuthOptions");
      services.Configure<AuthOptions>(Configuration.GetSection("AuthOptions"));
      var appSettings = appSettingsSection.Get<AuthOptions>();

      var byteKey = Encoding.ASCII.GetBytes(appSettings.Key);
      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(options =>
      {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidIssuer = appSettings.Issuer,
          ValidAudience = appSettings.Audience,
          ValidateLifetime = true,
          IssuerSigningKey = new SymmetricSecurityKey(byteKey),
          ValidateIssuerSigningKey = true,
        };
      });

      services.Configure<IdentityOptions>(options =>
      {
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;
      });
      services.AddIdentity<Player, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();

      services.Configure<CookiePolicyOptions>(options =>
      {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      services.AddCors();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory fac)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseMiddleware<ExceptionLoggingMiddleware>();

      app.UseAuthentication();
      app.UseCookiePolicy();
      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
