using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess
{
    public interface IBaseGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(string id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Func<TEntity, bool> predicate);

        Task Add(TEntity item);

        Task AddRange(List<TEntity> item);

        void Remove(string id);

        void Update(TEntity item);

        int Count();
    }
}
