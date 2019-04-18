using System.Collections.Generic;
using System.Threading.Tasks;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories
{
    public class CardEfRepository : MainGameEfRepository<Card>, ICardRepository
    {
        public CardEfRepository(ApplicationContext context) : base(context)
        {
        }


        // ???

        public Task<List<Card>> GetCardFromGame(List<CardMove> list, string playerId)
        {
            throw new System.NotImplementedException();
        }
    }
}
