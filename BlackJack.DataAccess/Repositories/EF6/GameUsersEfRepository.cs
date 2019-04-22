using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories
{
    public class GameUsersEfRepository : MainGameEfRepository<GameUsers>, IGameUsersRepository
    {
        public GameUsersEfRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task AddPlayersToGame(List<GameUsers> list)
        {
            _context.GameUsers.AddRange(list);
            _context.SaveChanges();
        }

        public async Task<List<string>> GetBotsIdList(string userId, string gameId)
        {
            var list = _context.GameUsers
               .Where(t => t.GameId == gameId && t.UserId != userId)
               .Select(x => x.UserId)
               .ToList();
            return list;
        }

        public async Task<GameUsers> GetWinner(string playerId, string gameId)
        {
            var winner = _context.GameUsers.Single(t => t.UserId == playerId && t.GameId == gameId);
            return winner;
        }

        public async Task UpdateWinner(GameUsers player)
        {
            _context.GameUsers.Update(player);
            _context.SaveChanges();
        }

    }
}
