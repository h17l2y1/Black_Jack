using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
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

            var playersList = await GetPlayers(userId, game.Id, countBots);

            await Start(userId, game.Id, playersList);

            var gameModel = CreateStartGameModel(userId, game.Id);

            return await gameModel;
        }

        public async Task<ResponseCardGameView> AddOneCard(string userId, string gameId)
        {
            List<Player> player = new List<Player>();
            var user = _playerRepository.Get(userId);
            player.Add(user);

            var countMove = _cardMoveRepository.CountMove(gameId, user.UserName);

            var card = await AddCard(countMove, gameId, player);

            var response = new ResponseCardGameView
            {
                Ranks = card.Rank.ToString(),
                Suit = card.Suit.ToString(),
                Value = card.Value
            };
            return response;
        }

        public async Task<ResponseStopGameView> Stop(string userId, string gameId)
        {
            await AddOtherCardToBots(userId, gameId);
            var winner = await SearchWinner(gameId);
            var stopModel = await CreateStopGameModel(userId, gameId, winner);
            return stopModel;
        }

        //

        private async Task Start(string userId, string gameId, List<Player> playersList)
        {
            await AddPlayersToGame(playersList, gameId);
            await FirstMove(userId, gameId, playersList);
        }

        private async Task FirstMove(string userId, string gameId, List<Player> playersList)
        {
            int moveInt = 1;
            for (int i = 0; i < 2; i++)
            {
                await AddCard(moveInt, gameId, playersList);
            }

        }

        private async Task<Card> AddCard(int moveInt, string gameId, List<Player> players)
        {
            var listCardMoves = new List<CardMove>();
            var card = new Card();
            foreach (var item in players)
            {
                Card newCard = GetCard(gameId);
                var move = new CardMove
                {
                    GameId = gameId,
                    CardId = newCard.Id,
                    PlayerId = item.Id,
                    Name = item.UserName,
                    Role = item.Role,
                    Value = newCard.Value,
                    Move = moveInt
                };
                listCardMoves.Add(move);
                card = newCard;
            }
            await _cardMoveRepository.AddCardToPlayer(listCardMoves);
            return card;
        }

        private async Task<List<Player>> GetPlayers(string userId, string gameId, int countBots)
        {
            var botsList = await _playerRepository.FindBots();
            List<Player> players = new List<Player>();
            players.Add(_playerRepository.Get(userId));
            players.Add(await _playerRepository.FindDialer());

            for (int i = 0; i < countBots; i++)
            {
                players.Add(botsList.FindAll(t => t.UserName != "Dialer")[i]);
            }
            return players;
        }


        // add other cards

        private async Task<List<Player>> GetBotsList(string userId, string gameId)
        {
            var botsList = new List<Player>();
            var botsIdList = await _gameUsersRepository.GetBotsIdList(userId, gameId);
            foreach (var id in botsIdList)
            {
                botsList.Add(_playerRepository.Get(id));
            }
            return botsList;
        }

        private async Task AddOtherCardToBots(string userId, string gameId)
        {
            var botList = await GetBotsList(userId, gameId);

            var botsCardMoveList = await _cardMoveRepository.BotsCardMoveList(gameId, userId);

            var playersCount = botsCardMoveList
                .GroupBy(x => x.PlayerId)
                .Select(x => new
                {
                    Name = x.Key,
                    Total = x.Sum(f => f.Value),
                    Move = x.Sum(t => t.Move)
                })
                .OrderBy(x => x.Total);

            foreach (var item in playersCount)
            {
                if (item.Total < 17)
                {
                    var player = new List<Player>();

                    player.Add(botList.Single(t => t.Id == item.Name));

                    await AddCard(item.Move, gameId, player);

                    playersCount = botsCardMoveList
                    .GroupBy(x => x.PlayerId)
                    .Select(x => new
                    {
                        Name = x.Key,
                        Total = x.Sum(f => f.Value),
                        Move = x.Sum(t => t.Move)
                    })
                    .OrderBy(x => x.Total);
                }
            }
        }


        // other methods

        private void SaveToCache(string gameId, Deck deck)
        {
            _cache.SaveToCache(gameId, deck);
        }

        private Card GetCard(string gameId)
        {
            var a = _cache.GetFromCache<Deck>(gameId) ?? _deck;
            Card card = _deck.GetCard();
            SaveToCache(gameId, _deck);

            return card;
        }

        private async Task<List<object>> SearchWinner(string gameId)
        {
            var cardMoveList = await _cardMoveRepository.GetMovesFromGame(gameId);
            var playersCount = cardMoveList
                .GroupBy(x => x.PlayerId)
                .Select(x => new
                {
                    PlayerId = x.Key,
                    Name = _playerRepository.Get(x.Key).UserName,
                    Value = x.Sum(f => f.Value)
                })
                .OrderBy(x => x.Value);

            var winnersList = new List<object>();
            var winners = playersCount
                .Where(x => x.Value < 21)
                .MaxBy(z => z.Value)
                .ToList();
            winnersList.AddRange(winners);

            foreach (var winner in winners)
            {
                _gameUsersRepository.UpdateWinner(winner.PlayerId, gameId);
            }

            return winnersList;
        }

        private async Task AddPlayersToGame(List<Player> playersId, string gameId)
        {
            var list = new List<GameUsers>();
            foreach (var player in playersId)
            {
                var gameToUser = new GameUsers
                {
                    GameId = gameId,
                    UserId = player.Id
                };
                list.Add(gameToUser);
            }
            await _gameUsersRepository.AddPlayersToGame(list);
        }

        private int GetCardValue(string cardId)
        {
            var card = _cardRepository.Get(cardId);
            return card.Value;
        }

        // View models

        private async Task<ResponseStartGameView> CreateStartGameModel(string userId, string gameId)
        {
            var botList = await GetBotsList(userId, gameId);
            var user = _playerRepository.Get(userId);
            var moveList = await _cardMoveRepository.GetMovesFromGame(gameId);

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
            var botList = await GetBotsList(userId, gameId);
            var user = _playerRepository.Get(userId);
            var moveList = await _cardMoveRepository.GetMovesFromGame(gameId);

            var gameModel = new ResponseStopGameView();
            gameModel.GameId = gameId;
            gameModel.User = await CreatePlayer(user, moveList);
            gameModel.Bots.AddRange(await GetBots(botList, moveList));
            gameModel.Cardsleft = _deck.CardsLeft();
            gameModel.Winner = winner;

            return gameModel;
        }

    }
}
