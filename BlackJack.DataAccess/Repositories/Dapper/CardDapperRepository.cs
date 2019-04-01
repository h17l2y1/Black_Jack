using BlackJackDataAccess.Repositories.Dapper.Interfaces;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class CardDapperRepository : DapperGenericRopository<Card>, ICardDapperRepository
    {
        public CardDapperRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
