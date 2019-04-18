using BlackJackEntities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface IGameUsersRepository : IMainGameRepository<GameUsers>
    {
        Task AddPlayersToGame(List<GameUsers> list);

        Task<List<string>> GetBotsIdList(string userId, string gameId);

        Task UpdateWinner(string playerId, string gameId);


        // old

        IEnumerable<dynamic> GetAllGamesFromPlayer(string userId);

        IEnumerable<dynamic> GetAllPlayersFromGame(string gameId);
    }
}
