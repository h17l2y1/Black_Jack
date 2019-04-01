using BlackJackDataAccess.Repositories.Dapper.Interfaces;
using BlackJackEntities.Entities;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class CardMoveDapperRepository : DapperGenericRopository<CardMove>, ICardMoveDapperRepository
    {
        private string _connectionString;

        public CardMoveDapperRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public object GetAllMovesFromGame(string gameId)
        {
            var sql = $"SELECT Move, Name, CardId FROM CardMoves WHERE GameId = '{ gameId }'";
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var game = connection.Query(sql);
                return game;
            }
        }
        
    }
}
