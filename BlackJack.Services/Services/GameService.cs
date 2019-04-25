using BlackJack.Exceptions;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using BlackJackServices.Exceptions;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Game;
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

        public GameService(
            ICacheWrapperService cache, IGameUsersRepository gameUsersRepository, ICardMoveRepository cardMoveRepository,
            IPlayerRepository playerRepository, ICardRepository cardRepository, IGameRepository gameRepository
            )
        {
            _cache = cache;
            _gameUsersRepository = gameUsersRepository;
            _cardMoveRepository = cardMoveRepository;
            _playerRepository = playerRepository;
            _cardRepository = cardRepository;
            _gameRepository = gameRepository;
            _deck = new Deck(_cardRepository.GetAll().ToList());
        }

        public async Task<ResponseStartGameView> Start(string userId, int countBots)
        {
            var game = new Game();
            await _gameRepository.AddGame(game);
            SaveToCache(game.Id, _deck);

            List<Player> playersList = await GetPlayers(userId, game.Id, countBots);
            await StartGame(userId, game.Id, playersList);

			ResponseStartGameView gameModel = await CreateStartGameModel(userId, game.Id);
            return gameModel;
        }

        public async Task<ResponseCardGameView> AddOneCard(string userId, string gameId)
        {
			// list because AddCard takes List<Player>
            var player = new List<Player>();
            Player user = _playerRepository.Get(userId);
            player.Add(user);

            int move = _cardMoveRepository.CountMove(gameId, user.UserName);
			if (move == 0)
			{
				throw new MoveNotFoundException();
			}
			Card card = await AddCard(move, gameId, player);
			ResponseCardGameView response = CardMapper(card);

            return response;
        }

        public async Task<ResponseStopGameView> Stop(string userId, string gameId)
        {
            await AddOtherCardToBots(userId, gameId);
            var winner = await SearchWinner(gameId);
            var stopModel = await CreateStopGameModel(userId, gameId, winner);
            return stopModel;
        }


		// Start

		private void SaveToCache(string gameId, Deck deck)
		{
			_cache.SaveToCache(gameId, deck);
		}

		private async Task<List<Player>> GetPlayers(string userId, string gameId, int countBots)
		{
			var players = new List<Player>();
			List<Player> botsList = await _playerRepository.FindBots();
			if (botsList == null)
			{
				throw new NotFoundException("Bots not Found");
			}
			Player user = _playerRepository.Get(userId);
			if (user == null)
			{
				throw new NotFoundException("User not Found");
			}
			Player dialer = await _playerRepository.FindDialer();
			if (dialer == null)
			{
				throw new NotFoundException("Dialer not Found");
			}
			players.Add(user);
			players.Add(dialer);
			for (int i = 0; i < countBots; i++)
			{
				players.Add(botsList.FindAll(t => t.UserName != "Dialer")[i]);
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
			var list = new List<GameUsers>();
			foreach (var player in playersList)
			{
				var newGameUser = new GameUsers
				{
					GameId = gameId,
					UserId = player.Id
				};
				list.Add(newGameUser);
			}
			await _gameUsersRepository.AddPlayersToGame(list);
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
            var card1 = new Card();
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
				card1 = card;
            }
            await _cardMoveRepository.AddCardToPlayer(listCardMoves);
            return card1;
        }

		private Card GetCard(string gameId)
		{
			var a = _cache.GetFromCache(gameId);

			var tempDeck = _cache.GetFromCache(gameId) ?? _deck;
			_deck = tempDeck;

			Card card = _deck.GetCard();
			SaveToCache(gameId, _deck);

			return card;
		}



		// Stop

		private async Task AddOtherCardToBots(string userId, string gameId)
		{
			List<Player> botList = await GetBotsFromGame(userId, gameId);
			List<CardMove> botsCardMoveList = await _cardMoveRepository.BotsCardMoveList(gameId, userId);
			if (botsCardMoveList == null)
			{
				throw new NotFoundException("AddOtherCardToBots()");
			}

			var playersCount = botsCardMoveList
				.GroupBy(x => x.PlayerId)
				.Select(x => new
				{
					Id = x.Key,
					Total = x.Sum(f => f.Value),
					Move = x.Sum(t => t.Move)
				})
				.OrderBy(x => x.Total);

			foreach (var item in playersCount)
			{
				if (item.Total < 17)
				{
					var player = new List<Player>();
					player.Add(botList.Single(t => t.Id == item.Id));
					await AddCard(item.Move, gameId, player);

					playersCount = botsCardMoveList
					.GroupBy(x => x.PlayerId)
					.Select(x => new
					{
						Id = x.Key,
						Total = x.Sum(f => f.Value),
						Move = x.Sum(t => t.Move)
					})
					.OrderBy(x => x.Total);
				}
			}
		}

		private void test()
		{

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

		private async Task<List<object>> SearchWinner(string gameId)
		{
			var cardMoveList = await _cardMoveRepository.GetMovesFromGame(gameId);
			if (cardMoveList == null)
			{
				throw new MoveNotFoundException();
			}
			var playersCount = cardMoveList
				.GroupBy(x => x.PlayerId)
				.Select(x => new
				{
					PlayerId = x.Key,
					Name = _playerRepository.Get(x.Key).UserName,
					Value = x.Sum(f => f.Value)
				})
				.OrderBy(x => x.Value);

			var winnersList = new List<object>();	//  <--- Winner/s
			var winners = playersCount
				.Where(x => x.Value < 21)
				.MaxBy(z => z.Value)
				.ToList();
			winnersList.AddRange(winners);

			foreach (var winner in winners)
			{
				var player = await _gameUsersRepository.GetWinner(winner.PlayerId, gameId);
				if (player == null)
				{
					throw new GameUserNotFoundException();
				}
				player.Winner = true;
				await _gameUsersRepository.UpdateWinner(player);
			}
			return winnersList;
		}



        // View models

        private async Task<ResponseStartGameView> CreateStartGameModel(string userId, string gameId)
        {
            List<Player> botList = await GetBotsFromGame(userId, gameId);
            Player user = _playerRepository.Get(userId);
            List<CardMove> moveList = await _cardMoveRepository.GetMovesFromGame(gameId);

            var gameModel = new ResponseStartGameView();
            gameModel.GameId = gameId;
            gameModel.User = await CreatePlayer(user, moveList);
            gameModel.Bots.AddRange(await GetBots(botList, moveList));
            gameModel.Cardsleft = _deck.CardsLeft();
            return gameModel;
        }

        private async Task<List<PlayerGameView>> GetBots(List<Player> botList, List<CardMove> moveList)
        {
            var list = new List<PlayerGameView>();
            foreach (var bot in botList)
            {
                list.Add(await CreatePlayer(bot, moveList));
            }
            return list;
        }

        private async Task<PlayerGameView> CreatePlayer(Player player, List<CardMove> moveList)
        {
            var playerMoves = moveList.Where(t => t.PlayerId == player.Id).ToList();
            var cardsList = new List<Card>();

            foreach (var move in playerMoves)
            {
                cardsList.Add(_cardRepository.Get(move.CardId));
            }

            var userView = new PlayerGameView();
            userView.Name = player.UserName;
            userView.Cards.AddRange(GetCardView(cardsList));
            userView.Score = GetScore(playerMoves);

            return userView;
        }

        private List<ResponseCardGameView> GetCardView(List<Card> cards)
        {
            var listCardView = new List<ResponseCardGameView>();
            foreach (var card in cards)
            {
                var cardModel = new ResponseCardGameView
                {
                    Ranks = card.Rank.ToString(),
                    Suit = card.Suit.ToString(),
                    Value = card.Value
                };
                listCardView.Add(cardModel);
            }
            return listCardView;
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

        private async Task<ResponseStopGameView> CreateStopGameModel(string userId, string gameId, List<object> winner)
        {
			List<Player> botList = await GetBotsFromGame(userId, gameId);
			Player user = _playerRepository.Get(userId);
			List<CardMove> moveList = await _cardMoveRepository.GetMovesFromGame(gameId);

			var gameModel = new ResponseStopGameView();
            gameModel.GameId = gameId;
            gameModel.User = await CreatePlayer(user, moveList);
            gameModel.Bots.AddRange(await GetBots(botList, moveList));
            gameModel.Cardsleft = _deck.CardsLeft();
            gameModel.Winner = winner;

            return gameModel;
        }

		private ResponseCardGameView CardMapper(Card card)
		{
			var response = new ResponseCardGameView
			{
				Ranks = card.Rank.ToString(),
				Suit = card.Suit.ToString(),
				Value = card.Value
			};
			return response;
		}

	}
}
