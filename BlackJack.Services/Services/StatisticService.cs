using BlackJack.Exceptions;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using BlackJackServices.Exceptions;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Game;
using BlackJackViewModels.Statistic;
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

		public async Task<ResponseGetGameStatisticView> GetGame(string gameId, string userName)
		{
			Player user = await _playerRepository.GetByName(userName);
			List<Player> botList = await GetBotsFromGame(user.Id, gameId);
			List<CardMove> moveList = await _cardMoveRepository.GetMovesFromGame(gameId);
			var userModel = CreatePlayer(user, moveList);
			var botsModel = GetBots(botList, moveList);
			var win = await _gameUsersRepository.GetWinner(gameId);
			var winner = _playerRepository.Get(win.UserId);

			var gameModel = new ResponseGetGameStatisticView
			{
				GameId = gameId,
				User = userModel,
				Bots = botsModel,
				Winner = winner.UserName
			};
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

		private async Task<List<Player>> GetBotsFromGame(string userId, string gameId)
		{
			var botsList = new List<Player>();

			// id bots from game
			var botsIdList = await _gameUsersRepository.GetBotsIdList(userId, gameId);
			if (botsIdList == null)
			{
				throw new NotFoundException();
			}

			// bots from game
			foreach (var id in botsIdList)
			{
				botsList.Add(_playerRepository.Get(id));
			}
			return botsList;
		}

		private PlayerStatisticView CreatePlayer(Player player, List<CardMove> moveList)
		{
			var playerMoves = moveList.Where(t => t.PlayerId == player.Id).ToList();
			var cardsList = new List<Card>();

			foreach (var move in playerMoves)
			{
				cardsList.Add(_cardRepository.Get(move.CardId));
			}

			var userView = new PlayerStatisticView();
			userView.Name = player.UserName;
			userView.Cards.AddRange(GetCardView(cardsList));
			userView.Score = GetScore(playerMoves);

			return userView;
		}

		private List<ResponseCardStatisticView> GetCardView(List<Card> cards)
		{
			var listCardView = new List<ResponseCardStatisticView>();
			foreach (var card in cards)
			{
				var cardModel = new ResponseCardStatisticView
				{
					Ranks = card.Rank.ToString(),
					Suit = card.Suit.ToString(),
					Value = card.Value
				};
				listCardView.Add(cardModel);
			}
			return listCardView;
		}

		private List<PlayerStatisticView> GetBots(List<Player> botList, List<CardMove> moveList)
		{
			var list = new List<PlayerStatisticView>();
			foreach (var bot in botList)
			{
				list.Add(CreatePlayer(bot, moveList));
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
