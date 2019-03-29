using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories
{
    public class CardRepository : BaseGenericRepository<Card>, ICardRepository
    {
        public CardRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
