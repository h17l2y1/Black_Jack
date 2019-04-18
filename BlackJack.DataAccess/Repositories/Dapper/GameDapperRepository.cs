using BlackJackDataAccess.Domain;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using Dapper;


using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class GameDapperRepository : MainGameDapperRepository<Game>, IGameRepository
    {
        public GameDapperRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
        {

        }

        public async Task AddGame(Game game)
        {
            var sql = $@"INSERT INTO Games(Id, CreationDate) VALUES(@Id, @CreationDate)";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Query(sql, game);
            }
        }
    }
}
