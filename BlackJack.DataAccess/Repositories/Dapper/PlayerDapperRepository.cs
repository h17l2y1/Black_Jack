using BlackJackDataAccess.Repositories.Interfaces.Dapper;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class PlayerDapperRepository : DapperGenericRopository<Player>, IPlayerDapperRepository
    {
        public PlayerDapperRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
