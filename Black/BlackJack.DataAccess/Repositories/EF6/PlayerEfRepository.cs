using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories
{
    public class PlayerEfRepository : MainGameEfRepository<Player>, IPlayerRepository
    {
        public PlayerEfRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
