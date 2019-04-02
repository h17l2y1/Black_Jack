using BlackJackDataAccess.Domain;
using BlackJackDataAccess.Repositories.Dapper.Interfaces;
using BlackJackEntities.Entities;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class GameUsersDapperRepository : DapperGenericRopository<GameUsers>, IGameUsersDapperRepository
    {
        private readonly string _connectionString;

        public GameUsersDapperRepository(IOptions<ConnectionConfig> connectionConfig) : base(connectionConfig)
        {
            var connection = connectionConfig.Value;
            _connectionString = connection.DefaultConnection;
        }

        public IEnumerable<dynamic> GetAllGamesFromPlayer(string userId)
        {
            var sql = $"SELECT GameId FROM GameUsers WHERE UserId = '{ userId }'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var order = connection.Query(sql);
                return order;
            }
        }

        public IEnumerable<dynamic> GetAllPlayersFromGame(string gameId)
        {
            var sql = $"SELECT UserId, Winner FROM GameUsers WHERE GameId = '{ gameId }'";
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var order = connection.Query(sql);
                return order;
            }
        }


    }
}
