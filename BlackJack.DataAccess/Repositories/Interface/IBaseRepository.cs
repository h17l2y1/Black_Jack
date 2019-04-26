using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Get(string id);

		Task Add(TEntity item);

		void Remove(string id);

		void Update(TEntity item);

		IQueryable<TEntity> GetAll();

    }
}
