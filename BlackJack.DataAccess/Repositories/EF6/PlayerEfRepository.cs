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
		private readonly string dilaer = "Dialer";
		private readonly string bot = "Bot";
		private readonly string user = "User";

		public PlayerEfRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<Player>> FindBots()
        {
            var listBots = await _context.Users
                .Where(t => t.Role == bot)
                .ToListAsync();
            return listBots;
        }

        public async Task<Player> FindDialer()
        {
            var listBots = await _context.Users
                .SingleOrDefaultAsync(t => t.UserName == dilaer);
            return listBots;
        }

        public async Task<List<Player>> GetAllUsers()
        {
            var listBots = await _context.Users
                .Where(t => t.Role == user)
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
