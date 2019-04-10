using BlackJackDataAccess.Repositories.Dapper;
using BlackJackDataAccess.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJackDataAccess.Repositories
{
    public static class Configuration
    {
        public static void DapperRepository(this IServiceCollection services)
        {
            services.AddTransient<IGameUsersRepository, GameUsersDapperRepository>();
            services.AddTransient<ICardMoveRepository, CardMoveDapperRepository>();
            services.AddTransient<IPlayerRepository, PlayerDapperRepository>();
            services.AddTransient<IGameRepository, GameDapperRepository>();
            services.AddTransient<ICardRepository, CardDapperRepository>();
        }

        public static void EfRepository(this IServiceCollection services)
        {
            services.AddScoped<IGameUsersRepository, GameUsersEfRepository>();
            services.AddScoped<ICardMoveRepository, CardMoveEfRepository>();
            services.AddScoped<IPlayerRepository, PlayerEfRepository>();
            services.AddScoped<IGameRepository, GameEfRepository>();
            services.AddScoped<ICardRepository, CardEfRepository>();
        }
    }
}
