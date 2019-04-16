using BlackJackEntities.Entities;
using System.Collections.Generic;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface IStatisticRepository : IMainGameRepository<Statistic>
    {
        List<Statistic> GetAllGames(int from);
    }
}
