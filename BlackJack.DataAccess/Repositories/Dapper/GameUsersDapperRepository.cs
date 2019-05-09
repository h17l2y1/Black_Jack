using BlackJackDataAccess.Domain;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Dapper
{
	public class GameUsersDapperRepository : MainGameDapperRepository<GameUser>, IGameUsersRepository
	{
		public GameUsersDapperRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
		{
		}

		public async Task<List<string>> GetBotsByUserIdAndGameId(string userId, string gameId)
		{
			var sql = $@"SELECT UserId FROM GameUsers WHERE GameId = '{gameId}' and UserId != '{userId}'";
			return (await Connection.QueryAsync<string>(sql)).ToList();
		}

		public async Task<List<CardMove>> GetAllMovesFromGame(string gameId)
		{
			var sql = $"SELECT * FROM GameUsers WHERE GameId = '{ gameId }'";
			return (await Connection.QueryAsync<CardMove>(sql)).ToList();
		}

		public async Task<List<GameUser>> GetGameUserFromGame(string gameId)
		{
			var sql = $"SELECT * FROM GameUsers WHERE GameId = '{ gameId }'";
			return (await Connection.QueryAsync<GameUser>(sql)).ToList();
		}

		public async Task<GameUser> GetFutureWinnerByPlayerIdAndGameId(string playerId, string gameId)
		{
			var sql = $@"SELECT * FROM GameUsers WHERE GameId = '{gameId}' and UserId = '{playerId}'";
			return await Connection.QuerySingleAsync<GameUser>(sql);
		}

		public async Task UpdateWinner(GameUser player)
		{
			var sql = $@"UPDATE GameUsers SET Winner = '1' WHERE GameId = '{player.GameId}' and UserId = '{player.UserId}'";
			await Connection.QueryAsync(sql);
		}

		public async Task<GameUser> GetWinnerByGameId(string gameId)
		{
			var sql = $@"SELECT * FROM GameUsers WHERE GameId = '{gameId}' and Winner = 1";
			return await Connection.QuerySingleAsync<GameUser>(sql);
		}

	}
}
