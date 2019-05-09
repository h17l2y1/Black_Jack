using BlackJackDataAccess.Domain;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            var sql = $@"
                        SELECT UserId FROM GameUsers
                        WHERE GameId = '{gameId}' and UserId != '{userId}'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
				var result = (await connection.QueryAsync<string>(sql)).ToList();
				return result;
            }
        }

        public async Task<List<CardMove>> GetAllMovesFromGame(string gameId)
        {
            var sql = $"SELECT * FROM GameUsers WHERE GameId = '{ gameId }'";
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
				var result = (await connection.QueryAsync<CardMove>(sql)).ToList();
				return result;
            }
        }

        public async Task<List<GameUser>> GetGameUserFromGame(string gameId)
        {
            var sql = $"SELECT * FROM GameUsers WHERE GameId = '{ gameId }'";
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
				var result = (await connection.QueryAsync<GameUser>(sql)).ToList();
				return result;
            }
        }

        public async Task<GameUser> GetFutureWinnerByPlayerIdAndGameId(string playerId, string gameId)
        {
            var sql = $@"
                        SELECT * 
                        FROM GameUsers
                        WHERE GameId = '{gameId}' and UserId = '{playerId}'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var result = await connection.QuerySingleAsync<GameUser>(sql);
                return result;
            }
        }

        public async Task UpdateWinner(GameUser player)
        {
            var sql = $@"
                        UPDATE GameUsers 
                        SET Winner = '1'
                        WHERE GameId = '{player.GameId}' and UserId = '{player.UserId}'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                await connection.QueryAsync(sql);
            }
        }

		public async Task<GameUser> GetWinnerByGameId(string gameId)
		{
			var sql = $@"
                        SELECT * 
                        FROM GameUsers
                        WHERE GameId = '{gameId}' and Winner = 1";

			using (IDbConnection connection = new SqlConnection(_connectionString))
			{
				var result = await connection.QuerySingleAsync<GameUser>(sql);
				return result;
			}
		}

	}
}
