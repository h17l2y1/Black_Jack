using BlackJackDataAccess.Repositories.Dapper;
using BlackJackDataAccess.Repositories.Dapper.Interfaces;
using BlackJackDataAccess.Repositories.Interfaces.Dapper;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJackDataAccess.Repositories
{
    public static class Configuration
    {
        public static void AddServcie(this IServiceCollection services)
        {
            services.AddTransient<IGameUsersDapperRepository, GameUsersDapperRepository>();
            services.AddTransient<ICardMoveDapperRepository, CardMoveDapperRepository>();
            services.AddTransient<IPlayerDapperRepository, PlayerDapperRepository>();
            services.AddTransient<IGameDapperRepository, GameDapperRepository>();
            //services.AddTransient<ICardDapperRepository, CardRepository>();
        }
    }
}
