using System.Linq;

namespace BlackJackDataAccess
{
	public class MainGameEfRepository<TEntity> : IMainGameRepository<TEntity> where TEntity : class
	{
		protected ApplicationContext _context;

		public MainGameEfRepository(ApplicationContext context)
		{
			_context = context;
		}

		public TEntity Get(string id)
		{
			return _context.Set<TEntity>().Find(id);
		}

		public IQueryable<TEntity> GetAll()
		{
			return _context.Set<TEntity>().AsQueryable();
		}

	}
}
