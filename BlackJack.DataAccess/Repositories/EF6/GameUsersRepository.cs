using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories
{
    public class GameUsersRepository : BaseGenericRepository<GameUsers>, IGameUsersRepository
    {
        public GameUsersRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
