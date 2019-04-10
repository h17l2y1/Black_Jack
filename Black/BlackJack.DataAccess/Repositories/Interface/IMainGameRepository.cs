using BlackJackDataAccess.Repositories.Interface;

namespace BlackJackDataAccess
{
    public interface IMainGameRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

    }
}
