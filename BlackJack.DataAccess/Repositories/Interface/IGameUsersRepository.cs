using BlackJackEntities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface IGameUsersRepository : IMainGameRepository<GameUser>
    {

        Task<List<string>> GetBotsByUserIdAndGameId(string userId, string gameId);

        Task<GameUser> GetFutureWinnerByPlayerIdAndGameId(string playerId, string gameId);

        Task UpdateWinner(GameUser player);

		Task<GameUser> GetWinnerByGameId(string gameId);

	}
}
