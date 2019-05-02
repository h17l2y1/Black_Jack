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
    public class CardMoveDapperRepository : MainGameDapperRepository<CardMove>, ICardMoveRepository
    {
        public CardMoveDapperRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
        {
        }

        public int CountMove(string gameId, string playerName)
        {
            var sql = $@"
                        SELECT COUNT(*)
                        FROM CardMoves
                        WHERE GameId='{gameId}' and Name='{playerName}'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var count = connection.QuerySingle<int>(sql);
                return count;
            }
        }

        public async Task AddCardToPlayer(CardMove move)
        {
            var sql = $@"
                        INSERT INTO CardMoves(Id, CreationDate, Move, Role, Name, Value, PlayerId, GameId, CardId) 
                        VALUES(@Id, @CreationDate, @Move, @Role, @Name, @Value, @PlayerId, @GameId, @CardId)";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
				await connection.QueryAsync(sql, move);
            }
        }

        public async Task<List<CardMove>> GetMovesFromGame(string gameId)
        {
            var sql = $@"
                        SELECT * FROM CardMoves
                        WHERE GameId='{gameId}'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
				var list = (await connection.QueryAsync<CardMove>(sql)).ToList();
				return list;
            }
        }

        public async Task<List<CardMove>> BotsCardMoveList(string gameId, string userId)
        {
            var sql = $@"
                        SELECT * FROM CardMoves
                        WHERE GameId='{gameId}' and PlayerId != '{userId}'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var list = (await connection.QueryAsync<CardMove>(sql)).ToList();
                return list;
            }
        }

    }
}
