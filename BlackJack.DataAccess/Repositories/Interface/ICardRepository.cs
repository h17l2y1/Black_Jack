using BlackJackEntities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface ICardRepository : IMainGameRepository<Card>
    {
        Task<List<Card>> GetCardFromGame(List<CardMove> list, string playerId);

    }
}
