using BlackJackDataAccess.Domain;
using BlackJackDataAccess.Repositories.Interfaces.Dapper;
using BlackJackEntities.Entities;
using Microsoft.Extensions.Options;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class PlayerDapperRepository : DapperGenericRopository<Player>, IPlayerDapperRepository
    {
        public PlayerDapperRepository(IOptions<ConnectionConfig> connectionConfig) : base(connectionConfig)
        {

        }
    }
}
