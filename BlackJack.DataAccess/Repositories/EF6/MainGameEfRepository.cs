using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackDataAccess
{
	public class MainGameEfRepository<TEntity> : IMainGameRepository<TEntity> where TEntity : class
	{
		protected ApplicationContext _context;

		public MainGameEfRepository(ApplicationContext context)
		{
			_context = context;
		}

		public async Task<TEntity> Get(string id)
		{
			return await _context.Set<TEntity>().FindAsync(id);
		}

		// ??
		public async Task<IEnumerable<TEntity>> GetAll()
		{
			return _context.Set<TEntity>();
		}

		//public IEnumerable<TEntity> GetAllOld()
		//{
		//	return _context.Set<TEntity>();
		//}

		public async Task Add(TEntity entity)
		{
			await _context.Set<TEntity>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}
	}
}
