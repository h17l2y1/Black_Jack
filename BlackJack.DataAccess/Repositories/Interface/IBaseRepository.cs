using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Interface
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		Task<TEntity> Get(string id);

		Task<IEnumerable<TEntity>> GetAll();

		Task Add(TEntity item);

		Task AddRange(List<TEntity> entity);

		Task Update(TEntity entity);

		Task Remove(string id);
	}
}
