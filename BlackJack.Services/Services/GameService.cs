using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackEntities.Entities;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Game;
using System;
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

            await CreateCardTable();
            await CreateBotTable();
            await CreateDialerTable();


            await Start(userId, game.Id, countBots);


            var gameModel = CreateStartGameModel(userId, game.Id, countBots);


            return gameModel;
        }

        private async Task Start(string userId, string gameId, int countBots)
        {
            await AddUserToGame(userId, gameId);

            await AddCardToUser(userId, gameId);
            await AddCardToBot(gameId, countBots);
            await AddCardToDialer(gameId);

        }



        // Add Card

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




        // Other

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
            user.Name = _userRepository.Get(userId).Name;
            user.Cards.AddRange(GetCardView(cards));
            
            // ???
            user.Score = GetScore(user.Cards);

            return user;
        }

        private PlayerView CreateDialer(IQueryable<CardMove> listCard)
        {
            var listDialer = new List<Dialer>();
            listDialer.AddRange(_dialerRepository.GetAll());
            var dialerEntity = listDialer[0];

            var cards = listCard.Where(t => t.Role == "Dialer").AsEnumerable();

            var dialer = new PlayerView();
            dialer.Name = _dialerRepository.Get(dialerEntity.Id).Name;
            dialer.Cards.AddRange(GetCardView(cards));

            // ???
            dialer.Score = GetScore(dialer.Cards);
            return dialer;
        }

        private PlayerView CreateBot(int i, IQueryable<CardMove> listCard)
        {
            var cards = listCard.Where(t => t.Name == $"Bot {i+1}").AsEnumerable();

            var botList = _botRepository.GetAll();

            var bot = new PlayerView();
            bot.Name = botList.FirstOrDefault(t => t.Name == $"Bot {i+1}").Name;
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
                cardModel.Value = card.Card.CardValue;

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
