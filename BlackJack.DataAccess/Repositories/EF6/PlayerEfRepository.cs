using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using Microsoft.EntityFrameworkCore;
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
            var listBots = await _context.Users
                .Where(t => t.Role == "Bot")
                .ToListAsync();
            return listBots;
        }

        public async Task<Player> FindDialer()
        {
            var listBots = await _context.Users
                .SingleOrDefaultAsync(t => t.UserName == "Dialer");
            return listBots;
        }

        public async Task<List<Player>> GetAllUsers()
        {
            var listBots = await _context.Users
                .Where(t => t.Role == "User")
				.ToListAsync();
			return listBots;
        }
    }
}
