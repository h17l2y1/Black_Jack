using System.Collections.Generic;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface IStatisticRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<dynamic> GetAllGamesFromPlayer(string userId);

        IEnumerable<dynamic> GetAllPlayersFromGame(string gameId);

        IEnumerable<dynamic> GetAllMovesFromGame(string gameId);
    }
}
