using System.Threading.Tasks;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories
{
    public class GameEfRepository : MainGameEfRepository<Game>, IGameRepository
    {
        public GameEfRepository(ApplicationContext context) : base(context)
        {

        }

        public async Task AddGame(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }
    }
}
