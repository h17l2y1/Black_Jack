using BlackJackDataAccess.Domain;
using BlackJackDataAccess.Repositories.Dapper.Interfaces;
using BlackJackEntities.Entities;
using Microsoft.Extensions.Options;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class CardDapperRepository : DapperGenericRopository<Card>, ICardDapperRepository
    {
        public CardDapperRepository(IOptions<ConnectionConfig> connectionConfig) : base(connectionConfig)
        {

        }
    }
}
