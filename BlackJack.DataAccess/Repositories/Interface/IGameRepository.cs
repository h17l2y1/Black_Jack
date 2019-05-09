using BlackJackEntities.Entities;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Interface
{
    public interface IGameRepository : IMainGameRepository<Game>
    {
    }
}
