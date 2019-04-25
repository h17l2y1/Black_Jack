using BlackJackEntities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface ICardMoveRepository : IMainGameRepository<CardMove>
    {
        int CountMove(string gameId, string playerName);

        Task AddCardToPlayer(List<CardMove> list);

        Task<List<CardMove>> GetMovesFromGame(string gameId);

        Task<List<CardMove>> BotsCardMoveList(string gameId, string userId);

    }
}
