using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories
{
    public class BotRepository : BaseGenericRepository<Bot>, IBotRepository
    {
        public BotRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
