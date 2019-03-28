using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories
{
    public class UserRepository : BaseGenericRepository<Player>, IPlayerRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
