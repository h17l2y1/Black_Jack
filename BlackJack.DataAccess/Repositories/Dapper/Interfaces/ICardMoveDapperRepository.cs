using BlackJackEntities.Entities;
using System.Collections.Generic;

namespace BlackJackDataAccess.Repositories.Dapper.Interfaces
{
    public interface ICardMoveDapperRepository : IBaseGenericRepository<CardMove>
    {
        IEnumerable<dynamic> GetAllMovesFromGame(string gameId);
    }
}
