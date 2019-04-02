using BlackJackEntities.Entities;
using System.Collections.Generic;

namespace BlackJackDataAccess.Repositories.Dapper.Interfaces
{
    public interface IGameUsersDapperRepository : IBaseGenericRepository<GameUsers>
    {
        IEnumerable<dynamic> GetAllGamesFromPlayer(string gameId);

        IEnumerable<dynamic> GetAllPlayersFromGame(string userId);
    }
}
