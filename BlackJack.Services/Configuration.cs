using BlackJackServices.Services;
using BlackJackServices.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJackServices
{
    public static class Configuration
    {
        public static void Service(this IServiceCollection services)
        {
            services.AddScoped<ICacheWrapperService, CacheWrapperService>();
            services.AddScoped<IStatisticService, StatisticService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IGameService, GameService>();
        }
    }
}
