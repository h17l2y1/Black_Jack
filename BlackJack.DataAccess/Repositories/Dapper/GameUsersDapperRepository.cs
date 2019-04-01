using BlackJackDataAccess.Repositories.Dapper.Interfaces;
using BlackJackEntities.Entities;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class GameUsersDapperRepository : DapperGenericRopository<GameUsers>, IGameUsersDapperRepository
    {
        private string _connectionString;

        public GameUsersDapperRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public object GetAllGamesFromPlayer(string userId)
        {
            var sql = $"SELECT GameId FROM GameUsers WHERE UserId = '{ userId }'";
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var order = connection.Query(sql);
                return order;
            }
        }

        public object GetAllPlayersFromGame(string gameId)
        {
            var sql = $"SELECT GameId, Winner FROM GameUsers WHERE GameId = '{ gameId }'";
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var order = connection.Query(sql);
                return order;
            }
        }
        

    }
}
