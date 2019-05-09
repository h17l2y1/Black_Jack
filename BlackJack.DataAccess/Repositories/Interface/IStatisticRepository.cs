using BlackJackEntities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface IStatisticRepository : IMainGameRepository<Statistic>
    {
        Task<List<Statistic>> GetAllGames(int offset, int size);

		Task<int> CountElements();

		Task<List<Statistic>> GetUserGames(int from, int size, string userName);

		Task<int> CountUsers(string userName);
	}
}
