using BlackJackDataAccess.Repositories.Interfaces;
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
        private readonly IGameRepository _gameRepository;
        private readonly IGameUsersRepository _gameUsersRepository;
        private readonly ICardMoveRepository _cardMoveRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly ICardRepository _cardRepository;

        public GameService(
            ICacheWrapperService cache, IGameRepository gameRepository, ICardMoveRepository cardMoveRepository,
            IGameUsersRepository gameUsersRepository, IPlayerRepository userRepository, ICardRepository cardRepository)
        {
            _cache = cache;
            _gameRepository = gameRepository;
            _gameUsersRepository = gameUsersRepository;
            _cardMoveRepository = cardMoveRepository;
            _playerRepository = userRepository;
            _cardRepository = cardRepository;
            _deck = new Deck(_cardRepository.GetAll().ToList());
        }

        public async Task<object> StartGame(string userId, int countBots)
        {
            var game = new Game();
            await _gameRepository.Add(game);

            SaveToCache(game.Id, _deck);

            var playersList = GetPlaeyrs(userId, game.Id, countBots);

            await Start(userId, game.Id, playersList);

            //var gameModel = CreateStartGameModel(userId, game.Id, countBots);


            return null;
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

            var winner = SearchWinner();
            return winner;
        }

        //

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

        private List<Player> GetPlaeyrs(string userId, string gameId, int countBots)
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




        // Good

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

        private object SearchWinner() 
        {
            var cardMoveList = new List<CardMove>();
            cardMoveList.AddRange(_cardMoveRepository.GetAll());

            var playersCount = cardMoveList
                .GroupBy(x => x.Name)
                .Select(x => new
                {
                    Name = x.Key,
                    Value = x.Sum(f => f.Value)
                })
                .OrderBy(x => x.Value);

            var winners = playersCount
                .Where(x => x.Value < 21)
                .MaxBy(z => z.Value)
                .ToList();

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





        // FIX

        //private async Task AddOtherCardToBots(string gameId)
        //{
        //    var list = new List<CardMove>();
        //    list.AddRange(_cardMoveRepository.Find(t => t.Role == "Bot"));

        //    var botsCount = list.
        //        GroupBy(x => x.Name).
        //        Select(x => x).Count();

        //    for (int i = 1; i < botsCount + 1; i++)
        //    {
        //        var bot = list.SingleOrDefault(item => item.Name == $"Bot {i}");

        //        int value = bot.Value;
        //        int nextMove = bot.Move;

        //        List<CardMove> moves = new List<CardMove>();
        //        while (value < 19)
        //        {
        //            string cardId = "999";
        //            var move = new CardMove
        //            {
        //                GameId = gameId,
        //                CardId = cardId,
        //                Name = $"Bot {i}",
        //                Role = "Bot",
        //                Value = GetCardValue(cardId),
        //                Move = nextMove += 1
        //            };
        //            moves.Add(move);
        //            value = value + move.Value;
        //        }
        //        await _cardMoveRepository.AddRange(moves);
        //    }
        //}

        //private async Task AddOtherCardToDialer(string gameId)
        //{
        //    var list = new List<CardMove>();
        //    list.AddRange(_cardMoveRepository.GetAll().Where(t => t.Role == "Dialer"));

        //    int value = 0;
        //    int nextMove = 0;

        //    foreach (var item in list)
        //    {
        //        if (item.Move > nextMove)
        //        {
        //            nextMove = item.Move;
        //        }

        //        value += item.Value;
        //    }

        //    while (value < 17)
        //    {
        //        string cardId = "999";
        //        var move = new CardMove
        //        {
        //            GameId = gameId,
        //            CardId = cardId,
        //            Name = "Dialer",
        //            Role = "Dialer",
        //            Value = GetCardValue(cardId),
        //            Move = nextMove + 1
        //        };
        //        await _cardMoveRepository.Add(move);
        //        value += move.Value;
        //    }
        //}













        // View models



        private StartGameView CreateStartGameModel(string userId, string gameId, int countBots)
        {
            var listCard = _cardMoveRepository.GetAll().Where(t => t.GameId == gameId);
            var gameModel = new StartGameView();
            gameModel.GameId = gameId;

            gameModel.User = CreateUser(userId, listCard);
            gameModel.Bots.Add(CreateDialer(listCard));

            for (int i = 0; i < countBots; i++)
            {
                gameModel.Bots.Add(CreateBot(i, listCard));
            }

            gameModel.Cardsleft = _deck.CardsLeft();


            return gameModel;
        }

        private PlayerView CreateUser(string userId, IQueryable<CardMove> listCard)
        {
            var cards = listCard.Where(t => t.Role == "user").AsEnumerable();

            var user = new PlayerView();
            user.Name = _playerRepository.Get(userId).UserName;
            user.Cards.AddRange(GetCardView(cards));
            user.Score = GetScore(user.Cards);

            return user;
        }

        private PlayerView CreateDialer(IQueryable<CardMove> listCard)
        {
            var dialerEntity = _playerRepository.Single(t => t.Role == "Dialer");
            var cards = listCard.Where(t => t.Role == "Dialer").AsEnumerable();

            var dialer = new PlayerView();
            dialer.Name = dialerEntity.UserName;
            dialer.Cards.AddRange(GetCardView(cards));
            dialer.Score = GetScore(dialer.Cards);

            return dialer;
        }

        private PlayerView CreateBot(int i, IQueryable<CardMove> listCard)
        {
            var cards = listCard.Where(t => t.Name == $"Bot {i + 1}").AsEnumerable();

            var botList = _playerRepository.GetAll();

            var bot = new PlayerView();
            bot.Name = botList.FirstOrDefault(t => t.UserName == $"Bot {i + 1}").UserName;
            bot.Cards.AddRange(GetCardView(cards));

            // ???
            bot.Score = GetScore(bot.Cards);
            return bot;
        }

        private IEnumerable<CardView> GetCardView(IEnumerable<CardMove> cards)
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

        private int GetScore(List<CardView> list)
        {
            int score = 0;
            foreach (var value in list)
            {
                score += value.Value;
            }
            return score;
        }

    }
}
