using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories
{
    public class DialerRepository : BaseGenericRepository<Dialer>, IDialerRepository
    {
        public DialerRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
