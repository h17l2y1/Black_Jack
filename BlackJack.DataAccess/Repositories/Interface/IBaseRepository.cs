using System.Linq;

namespace BlackJackDataAccess.Repositories.Interface
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		TEntity Get(string id);

		IQueryable<TEntity> GetAll();
	}
}
