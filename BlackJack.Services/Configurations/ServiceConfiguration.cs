using BlackJackDataAccess;
using BlackJackDataAccess.Domain;
using BlackJackEntities.Entities;
using BlackJackServices.Services;
using BlackJackServices.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using System.Collections.Generic;
using System.IO;

namespace BlackJackServices
{
    public static class Configuration
    {
		public static void Service(this IServiceCollection services, IConfiguration сonfiguration)
        {


			services.Configure<ConnectionStrings>(x => сonfiguration.GetSection("ConnectionStrings").Bind(x));
			services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(сonfiguration.GetSection("ConnectionStrings:DefaultConnection").Value));
			services.AddIdentity<Player, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();

			//services.EfRepository();
			services.DapperRepository();


			ServiceSettings(services, сonfiguration);
			JwtSettings(services, сonfiguration);
		}

		private static void JwtSettings(IServiceCollection services, IConfiguration сonfiguration)
		{
			var appSettingsSection = сonfiguration.GetSection("AuthOptions");
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
		}

		private static void ServiceSettings(IServiceCollection services, IConfiguration сonfiguration)
		{
			services.AddMemoryCache();

			services.AddScoped<ICacheWrapperService, CacheWrapperService>();
			services.AddScoped<IStatisticService, StatisticService>();
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IGameService, GameService>();
			services.AddScoped<IMappingService, MappingService>();

			services.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());
		}

	}

}
