using BlackJackDataAccess.Repositories.Dapper.Interfaces;
using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackDataAccess.Repositories.Interfaces.Dapper;
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

        private readonly IGameUsersDapperRepository _gameUsersDapperRepository;
        private readonly ICardMoveDapperRepository _cardMoveDapperRepository;
        private readonly IPlayerDapperRepository _playerDapperRepository;
        private readonly ICardDapperRepository _cardDapperRepository;
        private readonly IGameDapperRepository _gameDapperRepository;

        public GameService(
            ICacheWrapperService cache,
            IGameUsersRepository gameUsersRepository, IGameUsersDapperRepository gameUsersDapperRepository,
            ICardMoveRepository cardMoveRepository, ICardMoveDapperRepository cardMoveDapperRepository,
            IPlayerRepository playerRepository, IPlayerDapperRepository playerDapperRepository,
            ICardRepository cardRepository, ICardDapperRepository cardDapperRepository,
            IGameRepository gameRepository, IGameDapperRepository gameDapperRepository
            )
        {
            _cache = cache;

            // ef6
            _gameUsersRepository = gameUsersRepository; 
            _cardMoveRepository = cardMoveRepository;   
            _playerRepository = playerRepository;       
            _cardRepository = cardRepository;           
            _gameRepository = gameRepository;           

            // dapper
            _gameUsersDapperRepository = gameUsersDapperRepository;
            _cardMoveDapperRepository = cardMoveDapperRepository;
            _playerDapperRepository = playerDapperRepository;
            _cardDapperRepository = cardDapperRepository;
            _gameDapperRepository = gameDapperRepository;

            _deck = new Deck(_cardRepository.GetAll().ToList());
        }

        public async Task<object> StartGame(string userId, int countBots)
        {
            var game = new Game();
            await _gameRepository.Add(game);

            SaveToCache(game.Id, _deck);

            var playersList = GetPlayers(userId, game.Id, countBots);

            await Start(userId, game.Id, playersList);

            var gameModel = CreateStartGameModel(userId, game.Id);

            return gameModel;
        }

        public async Task AddOneCard(string userId, string gameId)
        {
            List<Player> player = new List<Player>();
            var user = _playerRepository.Get(userId);
            player.Add(user);

            var countMove = _cardMoveRepository
                .GetAll()
                .Where(t => t.GameId == gameId && t.Name == user.UserName)
                .ToList()
                .Count;

            await AddCard(countMove, gameId, player);
        }

        public async Task<object> Stop(string userId, string gameId)
        {
            await AddOtherCardToBots(userId, gameId);

            var winner = SearchWinner(gameId);
            return winner;
        }


        // start

        private async Task Start(string userId, string gameId, List<Player> playersList)
        {
            await AddPlayersToGame(playersList, gameId);
            await FirstMove(userId, gameId, playersList);
        }


        // First move

        private async Task FirstMove(string userId, string gameId, List<Player> playersList)
        {
            int moveInt = 1;
            for (int i = 0; i < 2; i++)
            {
                await AddCard(moveInt, gameId, playersList);
            }

        }

        private List<Player> GetPlayers(string userId, string gameId, int countBots)
        {
            var botsList = _playerRepository.Find(t => t.Role == "Bot").ToList();

            List<Player> players = new List<Player>();
            players.Add(_playerRepository.Get(userId));
            players.AddRange(_playerRepository.Find(t => t.UserName == "Dialer"));
            for (int i = 0; i < countBots; i++)
            {
                players.Add(botsList.FindAll(t => t.UserName != "Dialer")[i]);
            }

            return players;
        }

        private async Task AddCard(int moveInt, string gameId, List<Player> players)
        {
            var listCardMoves = new List<CardMove>();

            foreach (var item in players)
            {
                Card card = GetCard(gameId);
                var move = new CardMove
                {
                    GameId = gameId,
                    CardId = card.Id,
                    PlayerId = item.Id,
                    Name = item.UserName,
                    Role = item.Role,
                    Value = card.Value,
                    Move = moveInt
                };
                listCardMoves.Add(move);
            }
            await _cardMoveRepository.AddRange(listCardMoves);
        }


        // add other cards

        private List<Player> GetBotsList(string userId, string gameId)
        {
            var gameUserList = _gameUsersRepository
                .Find(t => t.GameId == gameId)
                .Where(x => x.UserId != userId);

            var playerIdList = new List<string>();

            foreach (var player in gameUserList)
            {
                playerIdList.Add(player.UserId);
            }

            var botsList = new List<Player>();

            var playersList = _playerRepository.GetAll().ToList();

            foreach (var palyer in playersList)
            {
                foreach (var id in playerIdList)
                {
                    if (palyer.Id == id)
                    {
                        botsList.Add(palyer);
                    }
                }
            }
            return botsList;
        }

        private async Task AddOtherCardToBots(string userId, string gameId)
        {
            var botList = GetBotsList(userId, gameId);

            var cardMovelist = _cardMoveRepository
                .Find(t => t.GameId == gameId)
                .Where(t => t.PlayerId != userId)
                .ToList();

            var playersCount = cardMovelist
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

                    playersCount = cardMovelist
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

        private object SearchWinner(string gameId)
        {
            var cardMoveList = new List<CardMove>();
            cardMoveList.AddRange(_cardMoveRepository.GetAll().Where(x => x.GameId == gameId));

            var gameUserList = new List<GameUsers>();
            gameUserList.AddRange(_gameUsersRepository.GetAll().Where(x => x.GameId == gameId));

            var playersCount = cardMoveList
                .GroupBy(x => x.PlayerId)
                .Select(x => new
                {
                    PlayerId = x.Key,
                    Value = x.Sum(f => f.Value)
                })
                .OrderBy(x => x.Value);

            var winners = playersCount
                .Where(x => x.Value < 21)
                .MaxBy(z => z.Value)
                .ToList();

            foreach (var player in gameUserList)
            {
                foreach (var winner in winners)
                {
                    if (player.UserId == winner.PlayerId)
                    {
                        var hod = gameUserList.Single(t=>t.UserId == winner.PlayerId && t.GameId == gameId);
                        hod.Winner = true;
                        _gameUsersRepository.Update(hod);
                    }
                }
            }
            return winners;
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
            await _gameUsersRepository.AddRange(list);
        }

        private int GetCardValue(string cardId)
        {
            var card = _cardRepository.Get(cardId);
            return card.Value;
        }


        // View models

        private StartGameView CreateStartGameModel(string userId, string gameId)
        {
            var botList = GetBotsList(userId, gameId);
            var user = _playerRepository.Get(userId);
            var listCard = _cardMoveRepository
                .GetAll()
                .Where(t => t.GameId == gameId)
                .ToList();

            var gameModel = new StartGameView();
            gameModel.GameId = gameId;
            gameModel.User = CreateUser(user, listCard);
            gameModel.Bots.AddRange(GetBots(botList, listCard));
            gameModel.Cardsleft = _deck.CardsLeft();

            return gameModel;
        }

        private List<PlayerView> GetBots(List<Player> botList, List<CardMove> listCard)
        {
            var list = new List<PlayerView>();
            foreach (var bot in botList)
            {
                list.Add(CreateUser(bot, listCard));
            }

            return list;
        }

        private PlayerView CreateUser(Player user, List<CardMove> listCard)
        {
            var cards = listCard.Where(t => t.PlayerId == user.Id).ToList();

            var userView = new PlayerView();
            userView.Name = user.UserName;
            userView.Cards.AddRange(GetCardView(cards));
            userView.Score = GetScore(cards);

            return userView;
        }

        private List<CardView> GetCardView(List<CardMove> cards)
        {
            var listCardView = new List<CardView>();
            foreach (var card in cards)
            {
                var cardModel = new CardView();
                cardModel.Ranks = card.Card.Rank.ToString();
                cardModel.Suit = card.Card.Suit.ToString();
                cardModel.Value = card.Card.Value;

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

    }
}
