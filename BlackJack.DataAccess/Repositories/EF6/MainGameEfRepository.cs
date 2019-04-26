using System;
using System.Collections.Generic;
using System.Linq;
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

        public TEntity Get(string id)
        {
            return _context.Set<TEntity>().Find(id);
        }
		
		public async Task Add(TEntity entity)
		{
			await _context.Set<TEntity>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public void Update(TEntity entity)
		{
			var putEntity = entity;
			_context.Set<TEntity>().Update(entity);
			_context.SaveChangesAsync();
		}

		public void Remove(string id)
		{
			_context.Set<TEntity>().Remove(Get(id));
			_context.SaveChanges();
		}

		public IQueryable<TEntity> GetAll()
		{
			return _context.Set<TEntity>().AsQueryable();
		}

    }
}
