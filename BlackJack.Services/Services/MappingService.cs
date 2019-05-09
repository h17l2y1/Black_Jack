using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Account;
using BlackJackViewModels.Game;
using BlackJackViewModels.Game.GetCard;
using BlackJackViewModels.Game.Stop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackServices.Services
{
	public class MappingService : IMappingService
	{
		private readonly ICardMoveRepository _cardMoveRepository;
		private readonly ICardRepository _cardRepository;

		public MappingService(ICardMoveRepository cardMoveRepository, ICardRepository cardRepository)
		{
			_cardMoveRepository = cardMoveRepository;
			_cardRepository = cardRepository;
		}

		// Other

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

		// Account
		public T AccountMapper<T>(Player player, T view) where T : PlayerAccountView
		{
			var response = view;
			view.UserId = player.Id;
			view.UserName = player.UserName;
			view.Points = player.Points;
			view.Role = player.Role;
			return response;
		}

		// AddCardView

		public GetCardStartView StartOneCardMapper(Card card)
		{
			var response = new GetCardStartView
			{
				Ranks = card.Rank.ToString(),
				Suit = card.Suit.ToString(),
				Value = card.Value
			};
			return response;
		}


		// Start

		public async Task<StartGameResponseViewItem> CreateStartGameModel(Player user, string gameId, List<Player> botPlayerList, int cardLeft)
		{
			List<CardMove> moveList = await _cardMoveRepository.GetByGameId(gameId);

			PlayerStartGameViewItem player = StartPlayerMapper(user, moveList);
			List<PlayerStartGameViewItem> botMoveList = StartGetBots(botPlayerList, moveList);

			var model = CreateStartModel(gameId, player, botMoveList, cardLeft);
			return model;
		}

		private PlayerStartGameViewItem StartPlayerMapper(Player player, List<CardMove> moveList)
		{
			List<Card> cardList = GetCardList(player, moveList);

			int score = GetScore(player, moveList);
			List<CardPlayerStartGameView> cardsView = StartCardMapper(cardList);
			PlayerStartGameViewItem model = StartPlayerMapper(player.UserName, cardsView, score);

			return model;
		}

		private List<CardPlayerStartGameView> StartCardMapper(List<Card> cards)
		{
			var model = cards
				.Select(x => new CardPlayerStartGameView
				{
					Rank = x.Rank.ToString(),
					Suit = x.Suit.ToString(),
					Value = x.Value
				})
				.ToList();
			return model;
		}

		private PlayerStartGameViewItem StartPlayerMapper(string userName, List<CardPlayerStartGameView> cardsView, int score)
		{
			var model = new PlayerStartGameViewItem
			{
				Name = userName,
				Cards = cardsView,
				Score = score
			};
			return model;
		}

		private List<PlayerStartGameViewItem> StartGetBots(List<Player> botList, List<CardMove> moveList)
		{
			var model = botList
				.Select(x => StartPlayerMapper(x, moveList))
				.ToList();
			return model;
		}

		public StartGameResponseViewItem CreateStartModel(string gameId, PlayerStartGameViewItem player,
												List<PlayerStartGameViewItem> botList, int cardLeft)
		{
			var model = new StartGameResponseViewItem
			{
				GameId = gameId,
				User = player,
				Bots = botList,
				Cardsleft = cardLeft
			};
			return model;
		}


		// Stop

		public async Task<StopGameResponseViewItem> CreateStopGameModel(Player user, string gameId, List<Winner> winner, List<Player> botPlayerList, int cardLeft)
		{
			List<CardMove> moveList = await _cardMoveRepository.GetByGameId(gameId);

			PlayerStopGameViewItem player = StopPlayerMapper(user, moveList);
			List<PlayerStopGameViewItem> botMoveList = StopGetBotsMapper(botPlayerList, moveList);
			List<WinnerStopGameView> winnersList = GetWinnerMapper(winner);

			var model = StopModelMapper(gameId, player, botMoveList, cardLeft, winnersList);
			return model;
		}

		private PlayerStopGameViewItem StopPlayerMapper(Player player, List<CardMove> moveList)
		{
			List<Card> cardList = GetCardList(player, moveList);

			int score = GetScore(player, moveList);
			List<CardPlayerStopGameView> cardsView = StopCardMapper(cardList);
			PlayerStopGameViewItem model = StopPlayerMapper(player.UserName, cardsView, score);

			return model;
		}

		private List<CardPlayerStopGameView> StopCardMapper(List<Card> cards)
		{
			var model = cards
				.Select(x => new CardPlayerStopGameView
				{
					Rank = x.Rank.ToString(),
					Suit = x.Suit.ToString(),
					Value = x.Value
				})
				.ToList();
			return model;
		}

		private PlayerStopGameViewItem StopPlayerMapper(string userName, List<CardPlayerStopGameView> cardsView, int score)
		{
			var model = new PlayerStopGameViewItem
			{
				Name = userName,
				Cards = cardsView,
				Score = score
			};
			return model;
		}

		private List<PlayerStopGameViewItem> StopGetBotsMapper(List<Player> botList, List<CardMove> moveList)
		{
			var model = botList
				.Select(x => StopPlayerMapper(x, moveList))
				.ToList();
			return model;
		}

		private StopGameResponseViewItem StopModelMapper(string gameId, PlayerStopGameViewItem player, List<PlayerStopGameViewItem> botList,
															int cardLeft, List<WinnerStopGameView> winners)
		{
			var model = new StopGameResponseViewItem
			{
				GameId = gameId,
				User = player,
				Bots = botList,
				Cardsleft = cardLeft,
				Winner = winners
			};
			return model;
		}

		private List<WinnerStopGameView> GetWinnerMapper(List<Winner> winner)
		{
			var model = winner
				.Select(x => new WinnerStopGameView
				{
					PlayerId = x.PlayerId,
					Name = x.Name,
					Value = x.Value
				})
				.ToList();
			return model;
		}
	}
}
