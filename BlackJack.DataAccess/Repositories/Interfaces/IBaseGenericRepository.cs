using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess
{
    public interface IBaseGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Func<TEntity, bool> predicate);

        void Add(TEntity item);

        void Remove(int id);

        void Update(TEntity item);
    }
}
