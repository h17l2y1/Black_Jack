using BlackJackDataAccess;
using BlackJackDataAccess.Repositories;
using BlackJackDataAccess.Repositories.Dapper;
using BlackJackDataAccess.Repositories.Dapper.Interfaces;
using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackDataAccess.Repositories.Interfaces.Dapper;
using BlackJackEntities.Entities;
using BlackJackServices;
using BlackJackServices.Services;
using BlackJackServices.Services.Auth;
using BlackJackServices.Services.Interfaces;
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
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;

namespace BlackJack
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            // connection sting
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetSection("DefaultConnection").Value));

            // services

            services.AddScoped<ICacheWrapperService, CacheWrapperService>();
            services.AddScoped<IStatisticService, StatisticService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserServices>();
            services.AddScoped<IGameService, GameService>();

            // EF6 repository
            services.AddScoped<IGameUsersRepository, GameUsersRepository>();
            services.AddScoped<ICardMoveRepository, CardMoveRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ICardRepository, CardRepository>();

            // Dapper
            services.AddTransient<IGameUsersDapperRepository>(f => new GameUsersDapperRepository(configuration.GetSection("DefaultConnection").Value));
            services.AddTransient<ICardMoveDapperRepository>(f => new CardMoveDapperRepository(configuration.GetSection("DefaultConnection").Value));
            services.AddTransient<IPlayerDapperRepository>(f => new PlayerDapperRepository(configuration.GetSection("DefaultConnection").Value));
            services.AddTransient<ICardDapperRepository>(f => new CardDapperRepository(configuration.GetSection("DefaultConnection").Value));
            services.AddTransient<IGameDapperRepository>(f => new GameDapperRepository(configuration.GetSection("DefaultConnection").Value));


            // cache
            services.AddMemoryCache();
            services.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());

            // jwt
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = AuthOptions.ISSUER,
                    ValidAudience = AuthOptions.AUDIENCE,
                    ValidateLifetime = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };
                options.SaveToken = true;
            });

            // identity
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

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200"));

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
