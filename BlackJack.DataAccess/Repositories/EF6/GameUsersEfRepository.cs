using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories
{
    public class GameUsersEfRepository : MainGameEfRepository<GameUsers>, IGameUsersRepository
    {
        public GameUsersEfRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
