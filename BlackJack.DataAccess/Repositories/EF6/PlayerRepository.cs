using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories
{
    public class PlayerRepository : BaseGenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
