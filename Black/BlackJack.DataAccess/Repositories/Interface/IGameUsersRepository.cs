using BlackJackEntities.Entities;
using System.Collections.Generic;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface IGameUsersRepository : IMainGameRepository<GameUsers>
    {
        IEnumerable<dynamic> GetAllGamesFromPlayer(string userId);

        IEnumerable<dynamic> GetAllPlayersFromGame(string gameId);
    }
}
