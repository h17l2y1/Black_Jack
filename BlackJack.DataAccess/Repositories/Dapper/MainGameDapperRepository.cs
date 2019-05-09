using BlackJackDataAccess.Domain;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories
{
	public class MainGameDapperRepository<TEntity> : IMainGameRepository<TEntity> where TEntity : class
	{
		protected readonly string _tableName = $"{ typeof(TEntity).Name }s";
		protected readonly string _connectionString;

		protected IDbConnection Connection
		{
			get { return new SqlConnection(_connectionString); }
		}

		public MainGameDapperRepository(IOptions<ConnectionStrings> connectionConfig)
		{
			var connection = connectionConfig.Value;
			_connectionString = connection.DefaultConnection;
		}

		public async Task<TEntity> Get(string id)
		{
			return await Connection.GetAsync<TEntity>(id);
		}

		public async Task<IEnumerable<TEntity>> GetAll()
		{
			return await Connection.GetAllAsync<TEntity>();
		}

		public async Task Add(TEntity item)
		{

			await Connection.InsertAsync(item);
		}
	}
}