using BlackJack.Exceptions;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using BlackJackServices.Exceptions;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Game;
using BlackJackViewModels.Statistic;
using BlackJackViewModels.Statistic.GetUserPage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackServices
{
	public class StatisticService : IStatisticService
	{
		private readonly IStatisticRepository _statisticRepository;
		private readonly IGameUsersRepository _gameUsersRepository;
		private readonly ICardMoveRepository _cardMoveRepository;
		private readonly IPlayerRepository _playerRepository;
		private readonly ICardRepository _cardRepository;

		public StatisticService(IStatisticRepository statisticRepository,
								IGameUsersRepository gameUsersRepository,
								ICardMoveRepository cardMoveRepository,
								IPlayerRepository playerRepository,
								ICardRepository cardRepository)
		{
			_statisticRepository = statisticRepository;
			_gameUsersRepository = gameUsersRepository;
			_cardMoveRepository = cardMoveRepository;
			_playerRepository = playerRepository;
			_cardRepository = cardRepository;
		}

		public async Task<GetGameStatisticViewItem> GetGame(string gameId, string userName)
		{
			Player user = await _playerRepository.GetByUserName(userName);
			List<Player> botList = await GetBotsFromGame(user.Id, gameId);
			List<CardMove> moveList = await _cardMoveRepository.GetByGameId(gameId);
			var userModel = await CreatePlayer(user, moveList);
			var botsModel = await GetBots(botList, moveList);
			var win = await _gameUsersRepository.GetWinnerByGameId(gameId);
			var winner = await _playerRepository.Get(win.UserId);

			var response = new GetGameStatisticViewItem
			{
				GameId = gameId,
				User = userModel,
				Bots = botsModel,
				Winner = winner.UserName
			};
			return response;
		}

		public async Task<GetPaginationStatisticViewItem> GetPagination(int pageNumber, int pageSize)
		{
			List<Statistic> page = await _statisticRepository.GetAllGames((pageNumber - 1) * pageSize, pageSize);
			if (page == null)
			{
				throw new NotFoundException("Page not found");
			}
			PageInfo info = await GetAllPageInfo(pageNumber, pageSize);
			GetPaginationStatisticViewItem response = CreateModel(page, info);
			return response;
		}

		public async Task<GetUserPageStatisticViewItem> GetUserStat(int pageNumber, int pageSize, string userName)
		{
			List<Statistic> page = await _statisticRepository.GetUserGames((pageNumber - 1) * pageSize, pageSize, userName);
			if (page.Count == 0)
			{
				throw new NotFoundException("Page not found");
			}
			PageInfo info = await GetUserPageInfo(pageNumber, pageSize, userName);
			GetUserPageStatisticViewItem response = UserCreateModel(page, info);
			return response;
		}

		private async Task<PageInfo> GetUserPageInfo(int pageNumber, int pageSize, string userName)
		{
			int totalItem = await _statisticRepository.CountUsers(userName);
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

		private GetPaginationStatisticViewItem CreateModel(List<Statistic> page, PageInfo info)
		{
			var response = new GetPaginationStatisticViewItem
			{
				Page = PageMapper(page),
				PageNumber = info.PageNumber,
				ItemsOnPage = info.ItemsOnPage,
				TotalItems = info.TotalItems,
				TotalPages = info.TotalPages
			};
			return response;
		}

		private List<StatisticGetPaginationStatisticView> PageMapper(List<Statistic> page)
		{
			var model = page
				.Select(x => new StatisticGetPaginationStatisticView
				{
					GameId = x.GameId,
					Score = x.Score,
					UserName = x.UserName,
					Winner = x.Winner
				})
				.ToList();
			return model;
		}

		private List<CardPlayerGetGameStatisticView> CardMapper(List<CardPlayerStartGameView> list)
		{
			var model = list
				.Select(x => new CardPlayerGetGameStatisticView
				{
					Ranks = x.Rank.ToString(),
					Suit = x.Suit.ToString(),
					Value = x.Value
				})
				.ToList();
			return model;
		}

		private async Task<List<Player>> GetBotsFromGame(string userId, string gameId)
		{
			var botsList = new List<Player>();

			// id bots from game
			var botsIdList = await _gameUsersRepository.GetBotsByUserIdAndGameId(userId, gameId);
			if (botsIdList == null)
			{
				throw new NotFoundException();
			}

			// bots from game
			foreach (var id in botsIdList)
			{
				botsList.Add(await _playerRepository.Get(id));
			}
			return botsList;
		}

		private GetUserPageStatisticViewItem UserCreateModel(List<Statistic> page, PageInfo info)
		{
			var response = new GetUserPageStatisticViewItem
			{
				Page = UserPageMapper(page),
				PageNumber = info.PageNumber,
				ItemsOnPage = info.ItemsOnPage,
				TotalItems = info.TotalItems,
				TotalPages = info.TotalPages
			};
			return response;
		}

		private List<StatisticGetUserPageStatisticView> UserPageMapper(List<Statistic> page)
		{
			var list = new List<StatisticGetUserPageStatisticView>();
			foreach (var item in page)
			{
				var stat = new StatisticGetUserPageStatisticView();
				stat.GameId = item.GameId;
				stat.Score = item.Score;
				stat.UserName = item.UserName;
				stat.Winner = item.Winner;
				list.Add(stat);
			}
			return list;
		}

		private async Task<PlayerGetGameStatisticViewItem> CreatePlayer(Player player, List<CardMove> moveList)
		{
			var playerMoves = moveList.Where(t => t.PlayerId == player.Id).ToList();
			var cardsList = new List<Card>();

			foreach (var move in playerMoves)
			{
				cardsList.Add( await _cardRepository.Get(move.CardId));
			}

			var userView = new PlayerGetGameStatisticViewItem();
			userView.Name = player.UserName;
			userView.Cards.AddRange(GetCardView(cardsList));
			userView.Score = GetScore(playerMoves);

			return userView;
		}

		private List<CardPlayerGetGameStatisticView> GetCardView(List<Card> cards)
		{
			var listCardView = new List<CardPlayerGetGameStatisticView>();
			foreach (var card in cards)
			{
				var cardModel = new CardPlayerGetGameStatisticView
				{
					Ranks = card.Rank.ToString(),
					Suit = card.Suit.ToString(),
					Value = card.Value
				};
				listCardView.Add(cardModel);
			}
			return listCardView;
		}

		private async Task<List<PlayerGetGameStatisticViewItem>> GetBots(List<Player> botList, List<CardMove> moveList)
		{
			var list = new List<PlayerGetGameStatisticViewItem>();
			foreach (var bot in botList)
			{
				list.Add(await CreatePlayer(bot, moveList));
			}
			return list;
		}

		private int GetScore(List<CardMove> cards)
		{
			int score = 0;
			foreach (var card in cards)
			{
				score += card.Value;
			}
			return score;
		}

	}
}
