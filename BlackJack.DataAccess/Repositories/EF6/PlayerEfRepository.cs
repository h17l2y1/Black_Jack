using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using BlackJackEntities.Enums;
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

		public async Task<Player> FindDialer()
		{
			var listBots = await _context.Users
				.SingleOrDefaultAsync(t => t.Role == Players.Dialer.ToString());
			return listBots;
		}

		public async Task<List<Player>> FindAnyBodyAsync(string role)
        {
            var listBots = await _context.Users
                .Where(t => t.Role == role)
                .ToListAsync();
            return listBots;
        }

		public async Task<Player> GetByName(string userName)
		{
			var listBots = await _context.Users
				.SingleOrDefaultAsync(t => t.UserName == userName);
			return listBots;
		}
	}
}
