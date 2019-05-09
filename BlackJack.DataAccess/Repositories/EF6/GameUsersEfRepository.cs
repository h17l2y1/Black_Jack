using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories
{
    public class GameUsersEfRepository : MainGameEfRepository<GameUser>, IGameUsersRepository
    {
        public GameUsersEfRepository(ApplicationContext context) : base(context)
        {
        }

		public async Task<List<string>> GetBotsByUserIdAndGameId(string userId, string gameId)
        {
            var result = await _context.GameUsers
               .Where(t => t.GameId == gameId && t.UserId != userId)
               .Select(x => x.UserId)
               .ToListAsync();
            return result;
        }

        public async Task<GameUser> GetFutureWinnerByPlayerIdAndGameId(string playerId, string gameId)
        {
            var result = await _context.GameUsers.SingleOrDefaultAsync(t => t.UserId == playerId && t.GameId == gameId);
            return result;
        }

		public async Task<GameUser> GetWinnerByGameId(string gameId)
		{
			var result = await _context.GameUsers.SingleOrDefaultAsync(t => t.Winner == true && t.GameId == gameId);
			return result;
		}

		public async Task UpdateWinner(GameUser player)
        {
            _context.GameUsers.Update(player);
			await _context.SaveChangesAsync();
		}

	}
}
