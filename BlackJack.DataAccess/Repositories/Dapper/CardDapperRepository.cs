using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BlackJackDataAccess.Domain;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using Dapper;
using Microsoft.Extensions.Options;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class CardDapperRepository : MainGameDapperRepository<Card>, ICardRepository
    {
        public CardDapperRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
        {

        }

        public async Task<List<Card>> GetCardFromGame(List<CardMove> list, string playerId)
        {
            var sql = $@"
                        SELECT * FROM Cards
                        WHERE GameId='{playerId}'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var cards = connection.Query<Card>(sql).ToList();
                return cards;
            }
        }

    }
}
