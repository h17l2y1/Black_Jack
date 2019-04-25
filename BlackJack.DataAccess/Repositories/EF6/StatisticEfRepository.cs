using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using System.Collections.Generic;

namespace BlackJackDataAccess.Repositories.EF6
{
	public class StatisticEfRepository : MainGameEfRepository<Statistic>, IStatisticRepository
	{
		public StatisticEfRepository(ApplicationContext context) : base(context)
		{

		}

		public List<Statistic> GetAllGames(int from, int size)
		{
			throw new System.NotImplementedException();
		}

		public List<Statistic> GetUserGames(int from, int size, string userName)
		{
			throw new System.NotImplementedException();
		}

		public int UserCount(string userName)
		{
			throw new System.NotImplementedException();
		}
	}
}
