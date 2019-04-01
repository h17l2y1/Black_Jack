using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories.Dapper.Interfaces
{
    public interface ICardMoveDapperRepository : IBaseGenericRepository<CardMove>
    {
        object GetAllMovesFromGame(string userId);
    }
}
