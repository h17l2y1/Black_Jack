using BlackJackEntities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface ICardMoveRepository : IMainGameRepository<CardMove>
    {
        int CountMove(string gameId, string playerName);

        Task<List<CardMove>> GetByGameId(string gameId);

        Task<List<CardMove>> GetByGameIdAndUserId(string gameId, string userId);

    }
}
