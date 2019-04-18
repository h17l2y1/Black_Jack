using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
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

        public IEnumerable<dynamic> GetAllMovesFromGame(string gameId)
        {
            var response = new List<dynamic>();

            var list = _context.Set<CardMove>()
                .Where(y => y.GameId == gameId)
                .Select(x => new
                {
                    x.Move,
                    x.Name,
                    x.CardId
                })
                .ToList();

            foreach (var item in list)
            {
                response.Add(item);
            }
            response.AsEnumerable();

            return response;
        }

        public async Task AddCardToPlayer(List<CardMove> list)
        {
            _context.CardMoves.AddRange(list);
            _context.SaveChanges();
        }

        public async Task<List<CardMove>> GetMovesFromGame(string gameId)
        {
            var listCard = _context.CardMoves
                .Where(t => t.GameId == gameId)
                .ToList();
            return listCard;
        }

        public async Task<List<CardMove>> BotsCardMoveList(string gameId, string userId)
        {
            var cardMovelist = _context.CardMoves
               .Where(t => t.GameId == gameId && t.PlayerId != userId)
               .ToList();
            return cardMovelist;
        }

    }
}
