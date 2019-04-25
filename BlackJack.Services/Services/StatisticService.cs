using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using BlackJackServices.Exceptions;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Game;
using BlackJackViewModels.Statistic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackServices
{
	public class StatisticService : IStatisticService
	{
		private readonly IGameService _gameService;
		private readonly IGameUsersRepository _gameUsersRepository;
		private readonly IStatisticRepository _statisticRepository;

		public StatisticService(IGameUsersRepository gameUsersRepository, IGameService gameService, IStatisticRepository statisticRepository)
		{
			_gameService = gameService;
			_gameUsersRepository = gameUsersRepository;
			_statisticRepository = statisticRepository;
		}

		public async Task<ResponseGetGameStatisticView> GetGame(string gameId, string playerId)
		{
			var stopModel = _gameService.Stop(playerId, gameId);

			var gameModel = new ResponseGetGameStatisticView();
			gameModel.Cardsleft = stopModel.Result.Cardsleft;
			gameModel.GameId = stopModel.Result.GameId;
			gameModel.Winner = stopModel.Result.Winner;
			// user
			gameModel.User.Name = stopModel.Result.User.Name;
			gameModel.User.Score = stopModel.Result.User.Score;
			gameModel.User.Cards.AddRange(CardMapper(stopModel.Result.User.Cards));
			//bot
			foreach (var bot in stopModel.Result.Bots)
			{
				var newBot = new PlayerStatisticView();
				newBot.Name = bot.Name;
				newBot.Score = bot.Score;
				newBot.Cards.AddRange(CardMapper(bot.Cards));
				gameModel.Bots.Add(newBot);
			}
			return gameModel;
		}

		public async Task<ResponsePaginationStatisticView> GetPagination(int pageNumber, int pageSize)
		{
			List<Statistic> page = _statisticRepository.GetAllGames((pageNumber - 1) * pageSize, pageSize);
			if (page == null)
			{
				throw new StatisticDataNotFound("Page not found");
			}
			PageInfo info = GetAllPageInfo(pageNumber, pageSize);
			ResponsePaginationStatisticView model = await CreateModel(page, info);
			return model;
		}

		public async Task<ResponsePaginationStatisticView> GetUserStat(int pageNumber, int pageSize, string userName)
		{
			List<Statistic> page = _statisticRepository.GetUserGames((pageNumber - 1) * pageSize, pageSize, userName);
			if (page.Count == 0)
			{
				throw new StatisticDataNotFound("Page not found");
			}
			PageInfo info = GetUserPageInfo(pageNumber, pageSize, userName);
			ResponsePaginationStatisticView model = await CreateModel(page, info);
			return model;
		}

		private PageInfo GetUserPageInfo(int pageNumber, int pageSize, string userName)
		{
			int totalItem = _statisticRepository.UserCount(userName);
			var info = GetPageInfo(pageNumber, pageSize, totalItem);
			return info;
		}

		private PageInfo GetAllPageInfo(int pageNumber, int pageSize)
		{
			int totalItem = _statisticRepository.Count();
			var info = GetPageInfo(pageNumber, pageSize, totalItem);
			return info;
		}

		private PageInfo GetPageInfo(int pageNumber, int pageSize, int totalItem)
		{
			var info = new PageInfo()
			{
				PageNumber = pageNumber,
				ItemsOnPage = pageSize,
				TotalItems = totalItem,
				TotalPages = GetTotalPages(totalItem,pageSize)
			};
			return info;
		}

		private int GetTotalPages(int totalItem, int pageSize)
		{
			int pages = 0;
			if ((totalItem % pageSize) == 0)
			{
				pages = totalItem / pageSize;
				return pages;
			}
			pages = totalItem / pageSize + 1;
			return pages;
		}

		private async Task<ResponsePaginationStatisticView> CreateModel(List<Statistic> page, PageInfo info)
		{
			var response = new ResponsePaginationStatisticView
			{
				Page = PageMapper(page),
				PageNumber = info.PageNumber,
				ItemsOnPage = info.ItemsOnPage,
				TotalItems = info.TotalItems,
				TotalPages = info.TotalPages
			};
			return response;
		}

		private List<StatisticStatisticView> PageMapper(List<Statistic> page)
		{
			var list = new List<StatisticStatisticView>();
			foreach (var item in page)
			{
				var stat = new StatisticStatisticView();
				stat.GameId = item.GameId;
				stat.Score = item.Score;
				stat.UserName = item.UserName;
				stat.Winner = item.Winner;
				list.Add(stat);
			}
			return list;
		}

		private List<ResponseCardStatisticView> CardMapper(List<ResponseCardGameView> list)
		{
			var listCard = new List<ResponseCardStatisticView>();
			foreach (var card in list)
			{
				var newCard = new ResponseCardStatisticView();
				newCard.Ranks = card.Ranks;
				newCard.Suit = card.Suit;
				newCard.Value = card.Value;
				listCard.Add(newCard);
			}
			return listCard;
		}

	}

}
