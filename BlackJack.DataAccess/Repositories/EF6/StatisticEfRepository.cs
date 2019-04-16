using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackDataAccess.Repositories.EF6
{
    public class StatisticEfRepository : MainGameEfRepository<Statistic>, IStatisticRepository
    {
        public StatisticEfRepository(ApplicationContext context) : base(context)
        {

        }

        public List<Statistic> GetAllGames(int from)
        {

            return null;
        }

    }
}
