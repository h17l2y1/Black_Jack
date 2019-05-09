using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using BlackJackEntities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.EF6
{
	public class StatisticEfRepository : MainGameEfRepository<Statistic>, IStatisticRepository
	{
		public StatisticEfRepository(ApplicationContext context) : base(context)
		{
		}

		public async Task<List<Statistic>> GetAllGames(int offset, int size)
		{
			var list = await _context.Games
				.Include(t => t.GameUsers)
					.ThenInclude(r => r.User)
				.Include(x => x.CardMoves)
				.Where(w => w.CardMoves.Any(s => s.Role == PlayersType.User.ToString()))
				.ToListAsync();

			var result = list.Select(s =>
				{
					var user = s.GameUsers.FirstOrDefault(p => p.User.Role == PlayersType.User.ToString());

					var stat = new Statistic
					{
						UserName = user.User.UserName,
						Winner = s.GameUsers.FirstOrDefault(gu => gu.UserId == user.UserId).Winner,
						Score = s.CardMoves.Where(w => w.PlayerId == user.UserId).Sum(p => p.Value),
						GameId = s.Id
					};
					return stat;
				})
				.OrderBy(o => o.GameId)
				.Skip(offset)
				.Take(size)
				.ToList();

			return result;
		}

		public async Task<int> CountElements()
		{
			var list = await _context.Games
				.Include(t => t.GameUsers)
					.ThenInclude(r => r.User)
				.Include(x => x.CardMoves)
				.Where(w => w.CardMoves.Any(s => s.Role == PlayersType.User.ToString()))
				.ToListAsync();

			var result = list.Select(s =>
			{
				var user = s.GameUsers.FirstOrDefault(p => p.User.Role == PlayersType.User.ToString());
				var stat = new Statistic
				{
					UserName = user.User.UserName,
					Winner = s.GameUsers.FirstOrDefault(gu => gu.UserId == user.UserId).Winner,
					Score = s.CardMoves.Where(w => w.PlayerId == user.UserId).Sum(p => p.Value),
					GameId = s.Id
				};
				return stat;
			})
			.OrderBy(o => o.GameId)
			.ToList()
			.Count;

			return result;
		}

		public async Task<List<Statistic>> GetUserGames(int offset, int size, string userName)
		{
			var list = await _context.Games
				.Include(t => t.GameUsers)
					.ThenInclude(r => r.User)
				.Include(x => x.CardMoves)
				.Where(w => w.GameUsers.Any(p => p.User.Role == PlayersType.User.ToString() && p.User.UserName == userName))
				.ToListAsync();

			var result = list.Select(s =>
			{
				var user = s.GameUsers.FirstOrDefault(p => p.User.Role == PlayersType.User.ToString());

				var stat = new Statistic
				{
					UserName = user.User.UserName,
					Winner = s.GameUsers.FirstOrDefault(gu => gu.UserId == user.UserId).Winner,
					Score = s.CardMoves.Where(w => w.PlayerId == user.UserId).Sum(p => p.Value),
					GameId = s.Id
				};
				return stat;
			})
				.OrderBy(o => o.GameId)
				.Skip(offset)
				.Take(size)
				.ToList();

			return result;
		}

		public async Task<int> CountUsers(string userName)
		{
			var list = await _context.Games
				.Include(t => t.GameUsers)
					.ThenInclude(r => r.User)
				.Include(x => x.CardMoves)
				.Where(w => w.GameUsers.Any(p => p.User.Role == PlayersType.User.ToString() && p.User.UserName == userName))
				.ToListAsync();

			var result = list.Select(s =>
			{
				var user = s.GameUsers.FirstOrDefault(p => p.User.Role == PlayersType.User.ToString());
				var stat = new Statistic
				{
					UserName = user.User.UserName,
					Winner = s.GameUsers.FirstOrDefault(gu => gu.UserId == user.UserId).Winner,
					Score = s.CardMoves.Where(w => w.PlayerId == user.UserId).Sum(p => p.Value),
					GameId = s.Id
				};
				return stat;
			})
			.OrderBy(o => o.GameId)
			.ToList()
			.Count;

			return result;
		}
	}
}
