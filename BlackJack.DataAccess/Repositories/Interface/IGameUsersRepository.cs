using BlackJackEntities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface IGameUsersRepository : IMainGameRepository<GameUsers>
    {
        Task AddPlayersToGame(List<GameUsers> list);

        Task<List<string>> GetBotsIdList(string userId, string gameId);

        Task<GameUsers> GetFutureWinner(string playerId, string gameId);

        Task UpdateWinner(GameUsers player);

		Task<GameUsers> GetWinner(string gameId);

	}
}
