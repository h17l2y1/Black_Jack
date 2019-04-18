using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories
{
    public class PlayerEfRepository : MainGameEfRepository<Player>, IPlayerRepository
    {
        public PlayerEfRepository(ApplicationContext context) : base(context)
        {

        }

        public async Task<List<Player>> FindBots()
        {
            var listBots = _context.Users
                .Where(t => t.Role == "Bot")
                .ToList();
            return listBots;
        }

        public async Task<Player> FindDialer()
        {
            var listBots = _context.Users
                .SingleOrDefault(t => t.UserName == "Dialer");
            return listBots;
        }
    }
}
