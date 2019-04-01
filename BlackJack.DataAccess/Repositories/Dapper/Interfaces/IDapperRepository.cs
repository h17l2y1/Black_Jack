
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Interfaces
{
    public interface IDapperRepository<TEntity> : IBaseGenericRepository<TEntity> where TEntity : class
    {

    }
}
