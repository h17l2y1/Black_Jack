using BlackJackDataAccess.Repositories.Dapper.Interfaces;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class GameDapperRepository : DapperGenericRopository<Game>, IGameDapperRepository
    {
        public GameDapperRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
