using BlackJackDataAccess.Repositories.Dapper.Interfaces;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class CardMoveDapperRepository : DapperGenericRopository<CardMove>, ICardMoveDapperRepository
    {
        public CardMoveDapperRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
