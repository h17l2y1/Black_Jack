using BlackJackEntities.Entities;
using System.Collections.Generic;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface IStatisticRepository : IMainGameRepository<Statistic>
    {
        List<Statistic> GetAllGames(int from, int size);

        int Count();

		List<Statistic> GetUserGames(int from, int size, string userName);

		int UserCount(string userName);
	}
}
