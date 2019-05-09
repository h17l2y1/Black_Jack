using BlackJackDataAccess;
using BlackJackEntities.Entities;
using BlackJackEntities.Enums;
using BlackJackServices.Jwt;
using BlackJackServices.Services;
using BlackJackServices.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Text;

namespace BlackJackServices
{
	public static class Configuration
	{
		public static void Service(this IServiceCollection services, IConfiguration сonfiguration)
		{
			string orm = сonfiguration.GetSection("Orm").Value;
			if (orm == OrmType.Entity.ToString())
			{
				services.EfRepository(сonfiguration);
			}
			if (orm == OrmType.Dapper.ToString())
			{
				services.DapperRepository(сonfiguration);
			}

			services.AddIdentity<Player, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();

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
			services.AddScoped<ICacheWrapperService, CacheWrapperService>();
			services.AddScoped<IStatisticService, StatisticService>();
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IGameService, GameService>();
			services.AddScoped<IMappingService, MappingService>();
			services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();

			services.AddMemoryCache();

			services.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());
		}

	}

}
