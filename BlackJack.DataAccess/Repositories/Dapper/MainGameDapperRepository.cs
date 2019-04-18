using BlackJackDataAccess.Domain;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

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

        public void Remove(string id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Delete(connection.Get<TEntity>(id));
            }
        }

        public async Task Add(TEntity item)
        {
            var a = item;
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Insert(item);
            }
        }

        public async Task AddRange(List<TEntity> list)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Insert(list);
            }
        }

        public void Update(TEntity item)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Update(item);
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<TEntity>().AsQueryable();
            }
        }

        public TEntity First()
        {
            var sql = $"SELECT * FROM {_tableName}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var order = connection.QueryFirst<TEntity>(sql);
                return order;
            }
        }

        public TEntity First(Func<TEntity, bool> predicate)
        {
            var sql = $"SELECT * FROM {_tableName}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var order = connection.QueryFirst<TEntity>(sql);
                return order;
            }
        }

        public TEntity FirstOrDefault()
        {
            var sql = $"SELECT * FROM {_tableName}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var order = connection.QueryFirstOrDefault<TEntity>(sql);
                return order;
            }
        }

        public TEntity FirstOrDefault(Func<TEntity, bool> predicate)
        {
            var sql = $"SELECT * FROM {_tableName}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var order = connection.QueryFirstOrDefault<TEntity>(sql);
                return order;
            }
        }

        public TEntity Single()
        {
            var sql = $"SELECT * FROM {_tableName}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var result = connection.QuerySingle<TEntity>(sql);
                return result;
            }
        }

        public TEntity Single(Func<TEntity, bool> predicate)
        {
            var sql = $"SELECT * FROM {_tableName}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var order = connection.QuerySingle<TEntity>(sql);
                return order;
            }
        }

        public TEntity SingleOrDefault()
        {
            var sql = $"SELECT * FROM {_tableName}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var order = connection.QuerySingleOrDefault<TEntity>(sql);
                return order;
            }
        }

        public TEntity SingleOrDefault(Func<TEntity, bool> predicate)
        {
            var sql = $"SELECT * FROM {_tableName}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var order = connection.QuerySingleOrDefault<TEntity>(sql);
                return order;
            }
        }

        public int Count()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<TEntity>().AsQueryable().Count();
            }
        }


        // need do

        public IQueryable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            var sql = $"SELECT * FROM {_tableName} WHERE {predicate}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var order = connection.Query<TEntity>(sql).AsQueryable();
                return null;
            }
        }

    }
}