using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackEntities.Entities;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Game;
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
        private readonly ICardRepository _cardRepository;
        private readonly IGameUsersRepository _gameUsersRepository;
        private readonly ICardMoveRepository _cardMoveRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBotRepository _botRepository;
        private readonly IDialerRepository _dialerRepository;

        public GameService(
            ICacheWrapperService cache, IGameRepository gameRepository, ICardRepository cardRepository,
            IGameUsersRepository gameUsersRepository, ICardMoveRepository cardMoveRepository, IUserRepository userRepository,
            IBotRepository botRepository, IDialerRepository dialerRepository)
        {
            _deck = new Deck();
            _cache = cache;
            _gameRepository = gameRepository;
            _cardRepository = cardRepository;
            _gameUsersRepository = gameUsersRepository;
            _cardMoveRepository = cardMoveRepository;
            _userRepository = userRepository;
            _botRepository = botRepository;
            _dialerRepository = dialerRepository;
        }

        public async Task<object> StartGame(string userId, int countBots)
        {
            var game = new Game();
            await _gameRepository.Add(game);

            SaveToCache(game.Id, _deck);

            var gameModel = CreateStartGameModel(countBots); // 

            await CreateCardTable();
            await CreateBotTable();
            await CreateDialerTable();


            await Start(userId, game.Id, countBots);


            return gameModel;
        }





        private async Task Start(string userId, string gameId, int countBots)
        {
            await AddUserToGame(userId, gameId);
            await AddCardToUser(userId, gameId);
            await AddCardToBot(gameId, countBots);

            await AddCardToDialer(gameId);


            //var botlist = CreateBotList();


            //await AddBotToGame(gameId, countBots);
            //var userCards = GetAllUserCard(userId, gameId);

        }





        private async Task AddCardToDialer(string gameId)
        {
            var listCardMoves = new List<CardMove>();
            var listDialer = new List<Dialer>();
            listDialer.AddRange(_dialerRepository.GetAll());

            var dialer = listDialer[0];

            for (int i = 1; i < 3; i++)
            {
                var move = new CardMove
                {
                    GameId = gameId,
                    CardId = GetCardId(gameId),
                    Name = dialer.Name,
                    Role = dialer.BotRole,
                    Move = i
                };

                listCardMoves.Add(move);
            }

            await _cardMoveRepository.AddRange(listCardMoves);
        }









        // work good \\

        private async Task AddCardToBot(string gameId, int countBots)
        {
            var listCardMoves = new List<CardMove>();
            var listBots = new List<Bot>();
            listBots.AddRange(_botRepository.GetAll().OrderBy(u => u.Name));

            for (int j = 0; j < countBots; j++)
            {
                var bot = listBots[j];

                for (int i = 1; i < 3; i++)
                {
                    var move = new CardMove
                    {
                        GameId = gameId,
                        CardId = GetCardId(gameId),
                        Name = bot.Name,
                        Role = bot.BotRole,
                        Move = i
                    };

                    listCardMoves.Add(move);
                }
            }

            await _cardMoveRepository.AddRange(listCardMoves);
        }

        private async Task AddCardToUser(string userId, string gameId)
        {
            var listCardMoves = new List<CardMove>();

            for (int i = 1; i < 3; i++)
            {
                var move = new CardMove
                {
                    GameId = gameId,
                    CardId = GetCardId(gameId),
                    Name = _userRepository.Get(userId).Name,
                    Role = _userRepository.Get(userId).UserRole,
                    Move = i
                };
                listCardMoves.Add(move);
            }
            await _cardMoveRepository.AddRange(listCardMoves);
        }

        private async Task AddUserToGame(string userId, string gameId)
        {
            var gameToUser = new GameUsers
            {
                GameId = gameId,
                UserId = userId
            };

            await _gameUsersRepository.Add(gameToUser);
        }

        public string GetCardId(string gameId)
        {
            _deck = _cache.GetFromCache<Deck>(gameId) ?? _deck;
            Card card = _deck.GetCard();
            SaveToCache(gameId, _deck);

            string cardId = GetCardIdFromTable(card);

            return cardId;
        }

        private string GetCardIdFromTable(Card card)
        {
            var deck = _cardRepository.GetAll();

            var result = deck
                .FirstOrDefault(t => t.Suit == card.Suit && t.Rank == card.Rank);

            return result.Id;
        }

        private void SaveToCache(string gameId, Deck deck)
        {
            _cache.SaveToCache(gameId, deck);
        }

        private List<Bot> CreateBotList()
        {
            var botsList = new List<Bot>();

            for (int i = 1; i < 6; i++)
            {
                var bot = new Bot();
                botsList.Add(new Bot()
                {
                    Name = $"Bot {i}"
                });
            }
            return botsList;
        }


        // Create Tables

        private async Task CreateCardTable()
        {
            if (_cardRepository.Count() == 0)
            {
                var cardsList = new Deck().ListOfCards;

                foreach (Card card in cardsList)
                {
                    var newCard = new BlackJackEntities.Entities.Card
                    {
                        CardValue = card.RankValue,
                        Rank = card.Rank,
                        Suit = card.Suit
                    };

                    await _cardRepository.Add(newCard);
                }
            }
        }

        private async Task CreateBotTable()
        {
            if (_botRepository.Count() == 0)
            {
                var botList = CreateBotList();
                await _botRepository.AddRange(botList);
            }
        }

        private async Task CreateDialerTable()
        {
            if (_dialerRepository.Count() == 0)
            {
                var dialer = new Dialer();
                await _dialerRepository.Add(dialer);
            }
        }




















        private StartGameView CreateStartGameModel(int countBots)
        {
            var gameModel = new StartGameView();
            gameModel.User = CreateUser();
            gameModel.Bots.Add(CreateDialer());

            for (int i = 0; i < countBots; i++)
            {
                gameModel.Bots.Add(CreateBot());
            }

            gameModel.Cardsleft = _deck.CardsLeft();


            return gameModel;
        }

        private PlayerView CreateUser()
        {
            var user = new PlayerView();
            user.Name = "USER";
            user.Cards.AddRange(GetTwoCard());
            user.Score = GetScore(user.Cards);

            return user;
        }

        private PlayerView CreateBot()
        {
            var bot = new PlayerView();
            bot.Name = "BOT";
            bot.Cards.AddRange(GetTwoCard());
            bot.Score = GetScore(bot.Cards);

            //bot = GetCardIfNeed(bot, 19);

            return bot;
        }

        private PlayerView CreateDialer()
        {
            var dialer = new PlayerView();
            dialer.Name = "DIALER";
            dialer.Cards.AddRange(GetTwoCard());
            dialer.Score = GetScore(dialer.Cards);

            //dialer = GetCardIfNeed(dialer, 17);

            return dialer;
        }

        private List<CardView> GetTwoCard()
        {
            var list = new List<CardView>();

            for (int i = 0; i < 2; i++)
            {
                list.Add(GetCardView());
            }

            return list;
        }

        public CardView GetCardView(/*string gameId*/)
        {
            var gameId = "11";

            _deck = _cache.GetFromCache<Deck>(gameId) ?? _deck;

            var card = _deck.GetCard();
            var cardModel = new CardView();
            cardModel.Ranks = card.Rank.ToString();
            cardModel.Suit = card.Suit.ToString();
            cardModel.Value = card.RankValue;

            SaveToCache(gameId, _deck);

            return cardModel;
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

        public PlayerView GetCardIfNeed(PlayerView player, int minScore)
        {
            player.Score = GetScore(player.Cards);

            while (true)
            {
                if (player.Score >= minScore)
                {
                    break;
                }
                player.Cards.Add(GetCardView());
                player.Score = GetScore(player.Cards);
            }

            return player;
        }
    }
}
