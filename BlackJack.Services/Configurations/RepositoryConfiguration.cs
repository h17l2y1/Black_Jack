using BlackJackDataAccess.Repositories;
using BlackJackDataAccess.Repositories.Dapper;
using BlackJackDataAccess.Repositories.EF6;
using BlackJackDataAccess.Repositories.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJackServices
{
	public static class RepositoryConfiguration
	{
		public static void DapperRepository(this IServiceCollection services, IConfiguration сonfiguration)
		{
			services.AddTransient<IGameUsersRepository, GameUsersDapperRepository>();
			services.AddTransient<IStatisticRepository, StatisticDapperRepository>();
			services.AddTransient<ICardMoveRepository, CardMoveDapperRepository>();
			services.AddTransient<IPlayerRepository, PlayerDapperRepository>();
			services.AddTransient<IGameRepository, GameDapperRepository>();
			services.AddTransient<ICardRepository, CardDapperRepository>();
		}

		public static void EfRepository(this IServiceCollection services, IConfiguration сonfiguration)
		{
			services.AddScoped<IGameUsersRepository, GameUsersEfRepository>();
			services.AddScoped<IStatisticRepository, StatisticEfRepository>();
			services.AddScoped<ICardMoveRepository, CardMoveEfRepository>();
			services.AddScoped<IPlayerRepository, PlayerEfRepository>();
			services.AddScoped<IGameRepository, GameEfRepository>();
			services.AddScoped<ICardRepository, CardEfRepository>();
		}
	}
}
