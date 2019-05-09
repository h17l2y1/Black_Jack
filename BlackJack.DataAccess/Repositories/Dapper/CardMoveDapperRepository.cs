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
	public class CardMoveDapperRepository : MainGameDapperRepository<CardMove>, ICardMoveRepository
	{
		public CardMoveDapperRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
		{
		}

		public int CountMove(string gameId, string playerName)
		{
			var sql = $@"SELECT COUNT(*) FROM CardMoves WHERE GameId='{gameId}' and Name='{playerName}'";
			return Connection.QuerySingle<int>(sql);
		}

		public async Task<List<CardMove>> GetByGameId(string gameId)
		{
			var sql = $@"SELECT * FROM CardMoves WHERE GameId='{gameId}'";
			return (await Connection.QueryAsync<CardMove>(sql)).ToList();
		}

		public async Task<List<CardMove>> GetByGameIdAndUserId(string gameId, string userId)
		{
			var sql = $@"SELECT * FROM CardMoves WHERE GameId='{gameId}' and PlayerId != '{userId}'";
			return (await Connection.QueryAsync<CardMove>(sql)).ToList();
		}


	}
}
