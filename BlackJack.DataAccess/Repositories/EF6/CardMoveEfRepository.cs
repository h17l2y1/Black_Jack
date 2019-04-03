using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackDataAccess.Repositories
{
    public class CardMoveEfRepository : MainGameEfRepository<CardMove>, ICardMoveRepository
    {
        public CardMoveEfRepository(ApplicationContext context) : base(context)
        {

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
    }
}
