using BlackJackDataAccess.Domain;
using BlackJackDataAccess.Repositories.Dapper.Interfaces;
using BlackJackEntities.Entities;
using Microsoft.Extensions.Options;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class GameDapperRepository : DapperGenericRopository<Game>, IGameDapperRepository
    {
        public GameDapperRepository(IOptions<ConnectionConfig> connectionConfig) : base(connectionConfig)
        {

        }
    }
}
