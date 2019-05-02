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
            var countMove = _context.CardMoves
                .Where(t => t.GameId == gameId && t.Name == playerName).Count();

            return countMove;
        }

        public async Task AddCardToPlayer(CardMove move)
        {
            await _context.CardMoves.AddAsync(move);
			await _context.SaveChangesAsync();
		}

		public async Task<List<CardMove>> GetMovesFromGame(string gameId)
        {
            var listCard = await _context.CardMoves
                .Where(t => t.GameId == gameId)
                .ToListAsync();
            return listCard;
        }

        public async Task<List<CardMove>> BotsCardMoveList(string gameId, string userId)
        {
            var cardMovelist = await _context.CardMoves
               .Where(t => t.GameId == gameId && t.PlayerId != userId)
			.ToListAsync();
			return cardMovelist;
        }

    }
}
