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
    public class CardMoveDapperRepository : DapperGenericRopository<CardMove>, ICardMoveDapperRepository
    {
        private readonly string _connectionString;

        public CardMoveDapperRepository(IOptions<ConnectionConfig> connectionConfig) : base(connectionConfig)
        {
            var connection = connectionConfig.Value;
            _connectionString = connection.DefaultConnection;
        }

        public IEnumerable<dynamic> GetAllMovesFromGame(string gameId)
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
