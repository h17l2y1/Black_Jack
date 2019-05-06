using BlackJackEntities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface IPlayerRepository : IMainGameRepository<Player>
    {
		Task<Player> GetByName(string userName);

		Task<Player> FindDialer();

		Task<List<Player>> FindAnyBodyAsync(string role);
    }
}
