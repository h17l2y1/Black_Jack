using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories
{
    public class CardMoveEfRepository : MainGameEfRepository<CardMove>, ICardMoveRepository
    {
        public CardMoveEfRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
