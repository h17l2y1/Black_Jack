using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess
{
    public class BaseGenericRepository<TEntity> : IBaseGenericRepository<TEntity> where TEntity : class
    {
        private ApplicationContext _context;

        public BaseGenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList().AsQueryable();
        }

        public IQueryable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().AsNoTracking().Where(predicate).AsQueryable();
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            var putEntity = entity;
            _context.Set<TEntity>().Update(entity);
            _context.SaveChangesAsync();
        }

        public void Remove(int id)
        {
            _context.Set<TEntity>().Remove(Get(id));
            _context.SaveChanges();
        }

    }
}
