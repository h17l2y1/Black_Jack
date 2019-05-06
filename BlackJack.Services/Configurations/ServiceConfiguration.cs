using BlackJackDataAccess;
using BlackJackDataAccess.Domain;
using BlackJackEntities.Entities;
using BlackJackServices.Services;
using BlackJackServices.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace BlackJackServices
{
    public static class Configuration
    {
		public static void Service(this IServiceCollection services,
										IConfigurationRoot configurationRoot,
										IConfiguration сonfiguration)
        {
			services.Configure<ConnectionStrings>(x => сonfiguration.GetSection("ConnectionStrings").Bind(x));
			services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configurationRoot.GetSection("ConnectionStrings:DefaultConnection").Value));
			services.AddIdentity<Player, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();

			services.AddScoped<ICacheWrapperService, CacheWrapperService>();
            services.AddScoped<IStatisticService, StatisticService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IGameService, GameService>();
        }

	}

}
