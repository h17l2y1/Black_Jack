using BlackJackDataAccess.Domain;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BlackJackDataAccess.Repositories
{
	public class MainGameDapperRepository<TEntity> : IMainGameRepository<TEntity> where TEntity : class
	{
		protected readonly string _tableName = $"{ typeof(TEntity).Name }s";

		protected readonly string _connectionString;

		public MainGameDapperRepository(IOptions<ConnectionStrings> connectionConfig)
		{
			var connection = connectionConfig.Value;
			_connectionString = connection.DefaultConnection;
		}

		public TEntity Get(string id)
		{
			using (IDbConnection connection = new SqlConnection(_connectionString))
			{
				return connection.Get<TEntity>(id);
			}
		}

		public IQueryable<TEntity> GetAll()
		{
			using (IDbConnection connection = new SqlConnection(_connectionString))
			{
				return connection.GetAll<TEntity>().AsQueryable();
			}
		}

	}
}