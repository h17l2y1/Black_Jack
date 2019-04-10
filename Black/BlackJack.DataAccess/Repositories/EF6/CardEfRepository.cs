using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories
{
    public class CardEfRepository : MainGameEfRepository<Card>, ICardRepository
    {
        public CardEfRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
