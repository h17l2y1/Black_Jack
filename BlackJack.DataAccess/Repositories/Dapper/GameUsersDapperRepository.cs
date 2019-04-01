using BlackJackDataAccess.Repositories.Dapper.Interfaces;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class GameUsersDapperRepository : DapperGenericRopository<GameUsers>, IGameUsersDapperRepository
    {
        public GameUsersDapperRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
