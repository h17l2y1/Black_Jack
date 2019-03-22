using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories
{
    public class CardMoveRepository : BaseGenericRepository<CardMove>, ICardMoveRepository
    {
        public CardMoveRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
