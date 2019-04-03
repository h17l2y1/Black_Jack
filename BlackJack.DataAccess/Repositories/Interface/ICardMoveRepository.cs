using BlackJackEntities.Entities;
using System.Collections.Generic;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface ICardMoveRepository : IMainGameRepository<CardMove>
    {
        IEnumerable<dynamic> GetAllMovesFromGame(string gameId);
    }
}
