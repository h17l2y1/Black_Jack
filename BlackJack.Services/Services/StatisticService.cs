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
			var stopModel = await _gameService.Stop(playerId, gameId);

			var gameModel = new ResponseGetGameStatisticView();
			gameModel.Cardsleft = stopModel.Cardsleft;
			gameModel.GameId = stopModel.GameId;
			gameModel.Winner = stopModel.Winner;
			// user
			gameModel.User.Name = stopModel.User.Name;
			gameModel.User.Score = stopModel.User.Score;
			gameModel.User.Cards.AddRange(CardMapper(stopModel.User.Cards));
			//bot
			foreach (var bot in stopModel.Bots)
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
			List<Statistic> page = await _statisticRepository.GetAllGames((pageNumber - 1) * pageSize, pageSize);
			if (page == null)
			{
				throw new StatisticDataNotFound("Page not found");
			}
			PageInfo info = await GetAllPageInfo(pageNumber, pageSize);
			ResponsePaginationStatisticView model = CreateModel(page, info);
			return model;
		}

		public async Task<ResponsePaginationStatisticView> GetUserStat(int pageNumber, int pageSize, string userName)
		{
			List<Statistic> page = await _statisticRepository.GetUserGames((pageNumber - 1) * pageSize, pageSize, userName);
			if (page.Count == 0)
			{
				throw new StatisticDataNotFound("Page not found");
			}
			PageInfo info = await GetUserPageInfo(pageNumber, pageSize, userName);
			ResponsePaginationStatisticView model = CreateModel(page, info);
			return model;
		}

		private async Task<PageInfo> GetUserPageInfo(int pageNumber, int pageSize, string userName)
		{
			int totalItem = await _statisticRepository.UserCount(userName);
			var info = GetPageInfo(pageNumber, pageSize, totalItem);
			return info;
		}

		private async Task<PageInfo> GetAllPageInfo(int pageNumber, int pageSize)
		{
			int totalItem = await _statisticRepository.CountElements();
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

		private ResponsePaginationStatisticView CreateModel(List<Statistic> page, PageInfo info)
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
