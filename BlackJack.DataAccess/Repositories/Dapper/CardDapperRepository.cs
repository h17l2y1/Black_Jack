using BlackJackDataAccess.Domain;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using Microsoft.Extensions.Options;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class CardDapperRepository : MainGameDapperRepository<Card>, ICardRepository
    {
        public CardDapperRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
        {
        }
    }
}
