using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories
{
    public class GameRepository : BaseGenericRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
