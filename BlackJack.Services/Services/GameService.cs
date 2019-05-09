using AutoMapper;
using BlackJack.Exceptions;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using BlackJackEntities.Enums;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Game;
using BlackJackViewModels.Game.GetCard;
using BlackJackViewModels.Game.Stop;
using MoreLinq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackServices.Services
{
	public class GameService : IGameService
	{
		private Deck _deck;
		private ICacheWrapperService _cache;
		private readonly IGameUsersRepository _gameUsersRepository;
		private readonly ICardMoveRepository _cardMoveRepository;
		private readonly IPlayerRepository _playerRepository;
		private readonly ICardRepository _cardRepository;
		private readonly IGameRepository _gameRepository;
		private readonly IMappingService _mappingService;

		public GameService(ICacheWrapperService cache,
						   IGameUsersRepository gameUsersRepository,
						   ICardMoveRepository cardMoveRepository,
						   IPlayerRepository playerRepository,
						   ICardRepository cardRepository,
						   IGameRepository gameRepository,
						   IMappingService mappingService
			)
		{
			_cache = cache;
			_gameUsersRepository = gameUsersRepository;
			_cardMoveRepository = cardMoveRepository;
			_playerRepository = playerRepository;
			_cardRepository = cardRepository;
			_gameRepository = gameRepository;
			_mappingService = mappingService;
		}

		public async Task<StartGameResponseViewItem> Start(string userId, int countBots)
		{
			IEnumerable<Card> deck = await _cardRepository.GetAll();
			_deck = new Deck(deck);
			var game = new Game();
			await _gameRepository.Add(game);
			_cache.SaveToCache(game.Id, _deck);

			List<Player> playersList = await GetPlayers(userId, game.Id, countBots);
			await StartGame(userId, game.Id, playersList);

			Player user = await _playerRepository.Get(userId);

			int cardLeft = _deck.CardsLeft();
			List<Player> botPlayerList = await GetBotsFromGame(user.Id, game.Id);

			StartGameResponseViewItem response = await CreateStartView(user, game.Id, cardLeft, botPlayerList);
			return response;
		}

		public async Task<GetCardStartView> AddOneCard(string userId, string gameId)
		{
			var player = new List<Player>();
			Player user = await _playerRepository.Get(userId);
			player.Add(user);

			int move = _cardMoveRepository.CountMove(gameId, user.UserName);
			if (move == 0)
			{
				throw new NotFoundException();
			}
			Card card = await AddCard(move, gameId, player);
			GetCardStartView response = CreateCardView(card);

			return response;
		}

		public async Task<StopGameResponseViewItem> Stop(string userId, string gameId)
		{
			await AddOtherCardToBots(userId, gameId);
			var winner = await SearchWinner(gameId);
			Player user = await _playerRepository.Get(userId);

			int cardLeft = _deck.CardsLeft();
			List<Player> botPlayerList = await GetBotsFromGame(user.Id, gameId);

			var response = await CreateStopView(user, gameId, winner, cardLeft, botPlayerList);
			return response;
		}


		// Start

		private async Task<List<Player>> GetPlayers(string userId, string gameId, int countBots)
		{
			var players = new List<Player>();
			List<Player> botsList = await _playerRepository.GetByRole(PlayersType.Bot.ToString());
			if (botsList == null)
			{
				throw new NotFoundException("Bots not Found");
			}
			Player user = await _playerRepository.Get(userId);
			if (user == null)
			{
				throw new NotFoundException("User not Found");
			}
			Player dialer = await _playerRepository.GetDialer();
			if (dialer == null)
			{
				throw new NotFoundException("Dialer not Found");
			}
			players.Add(user);
			players.Add(dialer);
			for (int i = 0; i < countBots; i++)
			{
				players.Add(botsList[i]);
			}

			return players;
		}

		private async Task StartGame(string userId, string gameId, List<Player> playersList)
		{
			await AddPlayersToGame(playersList, gameId);
			await FirstMove(userId, gameId, playersList);
		}

		private async Task AddPlayersToGame(List<Player> playersList, string gameId)
		{
			var list = new List<GameUser>();
			foreach (var player in playersList)
			{
				var newGameUser = new GameUser
				{
					GameId = gameId,
					UserId = player.Id
				};
				await _gameUsersRepository.Add(newGameUser);
			}
		}

		private async Task FirstMove(string userId, string gameId, List<Player> playersList)
		{
			int moveInt = 1;
			for (int i = 0; i < 2; i++)
			{
				await AddCard(moveInt, gameId, playersList);
			}
		}

		private async Task<Card> AddCard(int moveInt, string gameId, List<Player> playersList)
		{
			var listCardMoves = new List<CardMove>();
			var newCard = new Card();
			foreach (var player in playersList)
			{
				Card card = GetCard(gameId);
				var move = new CardMove
				{
					GameId = gameId,
					CardId = card.Id,
					PlayerId = player.Id,
					Name = player.UserName,
					Role = player.Role,
					Value = card.Value,
					Move = moveInt
				};
				listCardMoves.Add(move);
				newCard = card;
				await _cardMoveRepository.Add(move);
			}
			return newCard;
		}

		private Card GetCard(string gameId)
		{
			var deckFromCahe = _cache.GetFromCache(gameId);
			_deck = deckFromCahe;
			Card card = _deck.GetCard();
			_cache.SaveToCache(gameId, _deck);

			return card;
		}



		// Stop

		private async Task AddOtherCardToBots(string userId, string gameId)
		{
			List<Player> botList = await GetBotsFromGame(userId, gameId);
			List<InGame> playersCount = await InGameMapper(userId, gameId);

			foreach (var item in playersCount)
			{
				while (item.Total < 17)
				{
					var player = new List<Player>();
					player.Add(botList.Single(t => t.Id == item.Id));
					Card card = await AddCard(item.Move, gameId, player);
					item.Total += card.Value;
				}
			}
		}

		private async Task<List<InGame>> InGameMapper(string userId, string gameId)
		{
			List<CardMove> botsCardMoveList = await _cardMoveRepository.GetByGameIdAndUserId(gameId, userId);
			if (botsCardMoveList == null)
			{
				throw new NotFoundException("AddOtherCardToBots()");
			}
			var playersCount = botsCardMoveList
				.GroupBy(x => x.PlayerId)
				.Select(x => new InGame()
				{
					Id = x.Key,
					Total = x.Sum(f => f.Value),
					Move = x.Sum(t => t.Move)
				})
				.OrderBy(x => x.Total)
				.ToList();

			return playersCount;
		}

		private async Task<List<Player>> GetBotsFromGame2(string userId, string gameId)
		{
			var botsList = new List<Player>();

			List<string> botsIdList = await _gameUsersRepository.GetBotsByUserIdAndGameId(userId, gameId);
			if (botsIdList == null)
			{
				throw new NotFoundException();
			}

			var result = botsIdList
			.Select(x => _playerRepository.Get(x).Result)
			.ToList();

			return botsList;
		}

		private async Task<List<Player>> GetBotsFromGame(string userId, string gameId)
		{
			var botsList = new List<Player>();

			var botsIdList = await _gameUsersRepository.GetBotsByUserIdAndGameId(userId, gameId);
			if (botsIdList == null)
			{
				throw new NotFoundException();
			}

			foreach (var id in botsIdList)
			{
				botsList.Add(await _playerRepository.Get(id));
			}
			return botsList;
		}

		private async Task<List<Winner>> SearchWinner(string gameId)
		{
			var cardMoveList = await _cardMoveRepository.GetByGameId(gameId);
			if (cardMoveList == null)
			{
				throw new NotFoundException();
			}

			var playersCount = cardMoveList
				.GroupBy(r => r.PlayerId)
				.Select(x => GetWinners(x.Key, x.Sum(f => f.Value)).Result)
				.OrderBy(t => t.Value)
				.ToList();

			var winnersList = new List<Winner>();
			var winners = playersCount
				.Where(x => x.Value < 22)
				.MaxBy(z => z.Value)
				.ToList();
			winnersList.AddRange(winners);

			foreach (var winner in winners)
			{
				GameUser player = await _gameUsersRepository.GetFutureWinnerByPlayerIdAndGameId(winner.PlayerId, gameId);
				if (player == null)
				{
					throw new NotFoundException();
				}
				player.Winner = true;
				await _gameUsersRepository.UpdateWinner(player);
			}
			return winnersList;
		}

		private async Task<Winner> GetWinners(string key, int value)
		{
			Player player = await _playerRepository.Get(key);
			var winnerList = new Winner
			{
				Name = player.UserName,
				PlayerId = player.Id,
				Value = value
			};
			return winnerList;
		}

		private int GetScore(Player player, List<CardMove> moveList)
		{
			List<CardMove> cards = GetPlayerMoves(player, moveList);

			int score = 0;
			foreach (var card in cards)
			{
				score += card.Value;
			}

			return score;
		}

		private List<CardMove> GetPlayerMoves(Player player, List<CardMove> moveList)
		{
			List<CardMove> playerMoves = moveList
				.Where(t => t.PlayerId == player.Id)
				.ToList();
			return playerMoves;
		}

		private List<Card> GetCardList(Player player, List<CardMove> moveList)
		{
			List<CardMove> playerMoves = GetPlayerMoves(player, moveList);

			List<Card> cardList = playerMoves
				.Select(x => _cardRepository
				.Get(x.CardId)
				.Result)
				.ToList();
			return cardList;
		}


		// View

		private GetCardStartView CreateCardView(Card card)
		{
			var model = _mappingService.StartOneCardMapper(card);
			return model;
		}

		private async Task<StartGameResponseViewItem> CreateStartView(Player user, string gameId, int cardLeft, List<Player> botPlayerList)
		{
			var model = await _mappingService.CreateStartGameModel(user, gameId, botPlayerList, cardLeft);
			return model;
		}

		private async Task<StopGameResponseViewItem> CreateStopView(Player user, string gameId, List<Winner> winner, int cardLeft, List<Player> botPlayerList)
		{
			var model = await _mappingService.CreateStopGameModel(user, gameId, winner, botPlayerList, cardLeft);
			return model;
		}

	}
}
