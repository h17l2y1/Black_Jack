using BlackJackDataAccess.Repositories.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories
{
    public class DapperGenericRopository<TEntit> : IDapperRopository<TEntit> where TEntit : class
    {
        private readonly string _connectionString;

        protected readonly string _tableName = $"{ typeof(TEntit).Name }s";

        public DapperGenericRopository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TEntit Get(string id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Get<TEntit>(id);
            }
        }

        public void Remove(string id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Delete(connection.Get<TEntit>(id));
            }
        }

        public async Task Add(TEntit item)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Insert(item);
            }
        }

        public void Update(TEntit item)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Update(item);
            }
        }

        public IQueryable<TEntit> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<TEntit>().AsQueryable();
            }
        }



        // need do

        public Task AddRange(List<TEntit> item)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntit> Find(Func<TEntit, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntit First()
        {
            throw new NotImplementedException();
        }

        public TEntit First(Func<TEntit, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntit FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public TEntit FirstOrDefault(Func<TEntit, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntit Single()
        {
            throw new NotImplementedException();
        }

        public TEntit Single(Func<TEntit, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntit SingleOrDefault()
        {
            throw new NotImplementedException();
        }

        public TEntit SingleOrDefault(Func<TEntit, bool> predicate)
        {
            throw new NotImplementedException();
        }


    }
}
