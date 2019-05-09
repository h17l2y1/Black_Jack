using BlackJackDataAccess.Domain;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Dapper
{
	public class PlayerDapperRepository : MainGameDapperRepository<Player>, IPlayerRepository
	{
		public PlayerDapperRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
		{
		}

		public async Task<List<Player>> GetByRole(string role)
		{
			var sql = $@"SELECT * FROM AspNetUsers WHERE Role='{role}'";
			return (await Connection.QueryAsync<Player>(sql)).ToList();
		}

		public async Task<Player> GetDialer()
		{
			var sql = $@"SELECT * FROM AspNetUsers WHERE Role='Dialer'";
			return (await Connection.QuerySingleOrDefaultAsync<Player>(sql));
		}

		public async Task<Player> GetByUserName(string userName)
		{
			var sql = $@"SELECT * FROM AspNetUsers WHERE UserName='{userName}'";
			return (await Connection.QuerySingleOrDefaultAsync<Player>(sql));
		}

	}
}
