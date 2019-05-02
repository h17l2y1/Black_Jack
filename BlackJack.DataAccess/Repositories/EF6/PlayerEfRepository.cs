using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using BlackJackEntities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories
{
    public class PlayerEfRepository : MainGameEfRepository<Player>, IPlayerRepository
    {
		private static readonly string[] _players = Enum.GetNames(typeof(Players));

		private readonly string _dilaer = _players[0];
		private readonly string _bot = _players[1];
		private readonly string _user = _players[2];

		public PlayerEfRepository(ApplicationContext context) : base(context)
        {
		}

        public async Task<List<Player>> FindBots()
        {
            var listBots = await _context.Users
                .Where(t => t.Role == _bot)
                .ToListAsync();
            return listBots;
        }

        public async Task<Player> FindDialer()
        {
            var listBots = await _context.Users
                .SingleOrDefaultAsync(t => t.Role == _dilaer);
            return listBots;
        }

        public async Task<List<Player>> GetAllUsers()
        {
            var listBots = await _context.Users
                .Where(t => t.Role == _user)
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
