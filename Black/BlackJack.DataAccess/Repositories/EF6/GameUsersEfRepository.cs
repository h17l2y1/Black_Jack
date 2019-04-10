using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackDataAccess.Repositories
{
    public class GameUsersEfRepository : MainGameEfRepository<GameUsers>, IGameUsersRepository
    {
        public GameUsersEfRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<dynamic> GetAllGamesFromPlayer(string userId)
        {
            var response = new List<dynamic>();

            var list = _context.Set<GameUsers>()
                .Where(y => y.UserId == userId)
                .Select(x => new
                {
                    x.GameId
                })
                .ToList();

            foreach (var item in list)
            {
                response.Add(item);
            }
            response.AsEnumerable();

            return response;
        }

        public IEnumerable<dynamic> GetAllPlayersFromGame(string gameId)
        {
            var response = new List<dynamic>();

            var list = _context.Set<GameUsers>()
                .Where(y => y.GameId == gameId)
                .Select(x => new
                {
                    x.UserId
                })
                .ToList();

            foreach (var item in list)
            {
                response.Add(item);
            }
            response.AsEnumerable();

            return response;
        }
    }
}
