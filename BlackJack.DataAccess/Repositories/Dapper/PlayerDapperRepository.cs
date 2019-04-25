using BlackJackDataAccess.Domain;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Dapper
{
    public class PlayerDapperRepository : MainGameDapperRepository<Player>, IPlayerRepository
    {
        public PlayerDapperRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
        {

        }

        public async Task<List<Player>> FindBots()
        {
            var sql = $@"SELECT * FROM AspNetUsers WHERE Role='Bot'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var botList = (await connection.QueryAsync<Player>(sql)).ToList();
                return botList;
            }
        }

        public async Task<Player> FindDialer()
        {
            var sql = $@"SELECT * FROM AspNetUsers WHERE UserName='Dialer'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
				var dilaer = (await connection.QuerySingleOrDefaultAsync<Player>(sql));
				return dilaer;
            }
        }

        public async Task<List<Player>> GetAllUsers()
        {
            var sql = $@"SELECT * FROM AspNetUsers WHERE Role='User'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var users = (await connection.QueryAsync<Player>(sql)).ToList();
                return users;
            }
        }


    }
}
