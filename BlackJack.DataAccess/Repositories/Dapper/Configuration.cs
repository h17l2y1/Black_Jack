using BlackJackDataAccess.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public static class Configuration
    {

        public static void AddServcie(this IServiceCollection services)
        {
            services.AddTransient<IGameUsersRepository>(f => new GameUsersDapperRepository(configuration.GetSection("DefaultConnection").Value));
            services.AddTransient<ICardMoveRepository>(f => new CardMoveDapperRepository(configuration.GetSection("DefaultConnection").Value));
            services.AddTransient<IPlayerRepository>(f => new PlayerDapperRepository(configuration.GetSection("DefaultConnection").Value));
            services.AddTransient<ICardRepository>(f => new CardDapperRepository(configuration.GetSection("DefaultConnection").Value));
            services.AddTransient<IGameRepository>(f => new GameDapperRepository(configuration.GetSection("DefaultConnection").Value));
        }
    }
}
