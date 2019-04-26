using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories
{
    public class GameUsersEfRepository : MainGameEfRepository<GameUsers>, IGameUsersRepository
    {
        public GameUsersEfRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task AddPlayersToGame(List<GameUsers> list)
        {
            await _context.GameUsers.AddRangeAsync(list);
			await _context.SaveChangesAsync();
		}

		public async Task<List<string>> GetBotsIdList(string userId, string gameId)
        {
            var list = await _context.GameUsers
               .Where(t => t.GameId == gameId && t.UserId != userId)
               .Select(x => x.UserId)
               .ToListAsync();
            return list;
        }

        public async Task<GameUsers> GetFutureWinner(string playerId, string gameId)
        {
            var winner = await _context.GameUsers.SingleOrDefaultAsync(t => t.UserId == playerId && t.GameId == gameId);
            return winner;
        }

		public async Task<GameUsers> GetWinner(string gameId)
		{
			var winner = await _context.GameUsers.SingleOrDefaultAsync(t => t.Winner == true && t.GameId == gameId);
			return winner;
		}

		public async Task UpdateWinner(GameUsers player)
        {
            _context.GameUsers.Update(player);
			await _context.SaveChangesAsync();
		}

	}
}
