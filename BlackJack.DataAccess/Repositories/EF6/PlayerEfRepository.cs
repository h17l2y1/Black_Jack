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

		public async Task<Player> GetDialer()
		{
			var result = await _context.Users
				.SingleOrDefaultAsync(t => t.Role == PlayersType.Dialer.ToString());
			return result;
		}

		public async Task<List<Player>> GetByRole(string role)
        {
            var result = await _context.Users
                .Where(t => t.Role == role)
                .ToListAsync();
            return result;
        }

		public async Task<Player> GetByUserName(string userName)
		{
			var result = await _context.Users
				.SingleOrDefaultAsync(t => t.UserName == userName);
			return result;
		}
	}
}
