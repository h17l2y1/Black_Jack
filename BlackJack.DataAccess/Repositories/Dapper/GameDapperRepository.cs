using BlackJackDataAccess.Domain;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using Microsoft.Extensions.Options;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class GameDapperRepository : MainGameDapperRepository<Game>, IGameRepository
    {
        public GameDapperRepository(IOptions<ConnectionConfig> connectionConfig) : base(connectionConfig)
        {

        }
    }
}
