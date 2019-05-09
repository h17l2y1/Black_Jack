using BlackJackEntities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface IPlayerRepository : IMainGameRepository<Player>
    {
		Task<Player> GetByUserName(string userName);

		Task<Player> GetDialer();

		Task<List<Player>> GetByRole(string role);
    }
}
