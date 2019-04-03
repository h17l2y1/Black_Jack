using BlackJackDataAccess.Domain;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using Microsoft.Extensions.Options;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class PlayerDapperRepository : MainGameDapperRepository<Player>, IPlayerRepository
    {
        public PlayerDapperRepository(IOptions<ConnectionConfig> connectionConfig) : base(connectionConfig)
        {

        }
    }
}
