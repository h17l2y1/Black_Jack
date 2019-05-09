using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories
{
    public class CardMoveEfRepository : MainGameEfRepository<CardMove>, ICardMoveRepository
    {
        public CardMoveEfRepository(ApplicationContext context) : base(context)
        {
        }

        public int CountMove(string gameId, string playerName)
        {
            var result = _context.CardMoves
                .Where(t => t.GameId == gameId && t.Name == playerName).Count();

            return result;
        }

		public async Task<List<CardMove>> GetByGameId(string gameId)
        {
            var result = await _context.CardMoves
                .Where(t => t.GameId == gameId)
                .ToListAsync();
            return result;
        }

        public async Task<List<CardMove>> GetByGameIdAndUserId(string gameId, string userId)
        {
            var result = await _context.CardMoves
               .Where(t => t.GameId == gameId && t.PlayerId != userId)
			.ToListAsync();
			return result;
        }

    }
}
