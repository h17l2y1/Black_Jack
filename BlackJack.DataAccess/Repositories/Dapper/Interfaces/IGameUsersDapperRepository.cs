using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories.Dapper.Interfaces
{
    public interface IGameUsersDapperRepository : IBaseGenericRepository<GameUsers>
    {
        object GetAllGamesFromPlayer(string gameId);

        object GetAllPlayersFromGame(string userId);
    }
}
