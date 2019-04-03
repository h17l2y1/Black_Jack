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

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public TEntity Get(string id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity Single()
        {
            return _context.Set<TEntity>().Single();
        }

        public TEntity Single(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Single();
        }

        public TEntity SingleOrDefault()
        {
            return _context.Set<TEntity>().SingleOrDefault();
        }

        public TEntity SingleOrDefault(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().SingleOrDefault();
        }

        public TEntity First()
        {
            return _context.Set<TEntity>().First();
        }

        public TEntity FirstOrDefault()
        {
            return _context.Set<TEntity>().FirstOrDefault();
        }

        public TEntity First(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().First();
        }

        public TEntity FirstOrDefault(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault();
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
