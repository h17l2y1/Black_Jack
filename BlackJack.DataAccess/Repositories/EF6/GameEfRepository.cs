using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;

namespace BlackJackDataAccess.Repositories
{
	public class GameEfRepository : MainGameEfRepository<Game>, IGameRepository
	{
		public GameEfRepository(ApplicationContext context) : base(context)
		{
		}
	}
}
