using BlackJackEntities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface IPlayerRepository : IMainGameRepository<Player>
    {
        Task<List<Player>> FindBots();

        Task<Player> FindDialer();

        Task<List<Player>> GetAllUsers();
    }
}
