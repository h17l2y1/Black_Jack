using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public TEntity Get(string id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async Task Add(TEntity entity)
        {
            var result = _context.Set<TEntity>().Add(entity);
            var save = _context.SaveChanges();
        }

        public async Task AddRange(List<TEntity> entity)
        {
            var result = _context.Set<TEntity>().AddRangeAsync(entity);
            var save = _context.SaveChanges();
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

        public int Count()
        {
            return _context.Set<TEntity>().ToList().Count();
        }

        private bool _disposed = false;        protected virtual void Dispose(bool disposing)        {            if (!this._disposed)            {                if (disposing)                {                    _context.Dispose();                }            }            this._disposed = true;        }        public void Dispose()        {            Dispose(true);            GC.SuppressFinalize(this);        }

    }
}
