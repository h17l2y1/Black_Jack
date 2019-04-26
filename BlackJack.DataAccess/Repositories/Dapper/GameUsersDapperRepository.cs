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
    public class GameUsersDapperRepository : MainGameDapperRepository<GameUsers>, IGameUsersRepository
    {
        public GameUsersDapperRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
        {
        }

        public async Task AddPlayersToGame(List<GameUsers> list)
        {
            var sql = $@"
                        INSERT INTO GameUsers(Id, CreationDate, UserId, Winner, GameId) 
                        VALUES(@Id, @CreationDate, @UserId, @Winner, @GameId)";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    await connection.QueryAsync(sql, list[i]);
                }
            }
        }

        public async Task<List<string>> GetBotsIdList(string userId, string gameId)
        {
            var sql = $@"
                        SELECT UserId FROM GameUsers
                        WHERE GameId = '{gameId}' and UserId != '{userId}'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
				var list = (await connection.QueryAsync<string>(sql)).ToList();
				return list;
            }
        }

        public async Task<List<CardMove>> GetAllMovesFromGame(string gameId)
        {
            var sql = $"SELECT * FROM GameUsers WHERE GameId = '{ gameId }'";
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
				var list = (await connection.QueryAsync<CardMove>(sql)).ToList();
				return list;
            }
        }

        public async Task<List<GameUsers>> GetGameUserFromGame(string gameId)
        {
            var sql = $"SELECT * FROM GameUsers WHERE GameId = '{ gameId }'";
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
				var order = (await connection.QueryAsync<GameUsers>(sql)).ToList();
				return order;
            }
        }

        public async Task<GameUsers> GetFutureWinner(string playerId, string gameId)
        {
            var sql = $@"
                        SELECT * 
                        FROM GameUsers
                        WHERE GameId = '{gameId}' and UserId = '{playerId}'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var winner = await connection.QuerySingleAsync<GameUsers>(sql);
                return winner;
            }
        }

        public async Task UpdateWinner(GameUsers player)
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

		public async Task<GameUsers> GetWinner(string gameId)
		{
			var sql = $@"
                        SELECT * 
                        FROM GameUsers
                        WHERE GameId = '{gameId}' and Winner = 1";

			using (IDbConnection connection = new SqlConnection(_connectionString))
			{
				var winner = await connection.QuerySingleAsync<GameUsers>(sql);
				return winner;
			}
		}

	}
}
