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
            var list2 = _context.GameUsers.Where(t => t.GameId == gameId);


            var list = _context.GameUsers
               .Where(t => t.GameId == gameId && t.UserId != userId)
               .Select(x => x.UserId)
               .ToList();
            return list;
        }

        public async Task UpdateWinner(string playerId, string gameId)
        {
            var player = _context.GameUsers.Single(t => t.UserId == playerId && t.GameId == gameId);
            player.Winner = true;

            _context.GameUsers.Update(player);
            _context.SaveChanges();
        }


        // need refactor

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


        // need do mb

        public Task<List<CardMove>> GetAllMovesFromGame(string gameId)
        {
            throw new System.NotImplementedException();
        }

    }
}
