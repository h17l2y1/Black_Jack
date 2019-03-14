using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Game;
using System.Collections.Generic;

namespace BlackJackServices.Services
{
    public class GameService : IGameService
    {
        private readonly Deck _deck;

        public GameService(/*CacheWrapper cache*/)
        {
            _deck = new Deck();
            //_cache = cache;
        }

        public object StartGame(/*Guid*/ int userId, int countBots)
        {
            string id = userId.ToString();
            //SaveToCache(id, _deck);

            var gameModel = CreateStartGameModel(countBots);

            return gameModel;
        }


        private object CreateStartGameModel(int countBots)
        {
            var gameModel = new StartGameView();
            gameModel.Player = CreatePlayer();
            gameModel.Bots.Add(CreateDialer());

            for (int i = 0; i < countBots; i++)
            {
                gameModel.Bots.Add(CreateBot());
            }

            return gameModel;
        }

        private PlayerView CreatePlayer()
        {
            var player = new PlayerView();
            player.Name = "USER";
            player.Cards.AddRange(GetTwoCard());
            player.Score = GetScore(player.Cards);

            return player;
        }

        private PlayerView CreateBot()
        {
            var playerModel = new PlayerView();
            playerModel.Name = "BOT";
            playerModel.Cards.AddRange(GetTwoCard());
            playerModel.Score = GetScore(playerModel.Cards);

            return playerModel;
        }

        private PlayerView CreateDialer()
        {
            var dialer = new PlayerView();
            dialer.Name = "DIALER";
            dialer.Cards.AddRange(GetTwoCard());
            dialer.Score = GetScore(dialer.Cards);

            return dialer;
        }

        private List<CardView> GetTwoCard()
        {
            var list = new List<CardView>();

            for (int i = 0; i < 2; i++)
            {
                list.Add(CreateCard());
            }

            return list;
        }

        // card fix
        private CardView CreateCard()
        {
            var card = new Deck().GetCard();

            var cardModel = new CardView();
            cardModel.Ranks = card.Rank.ToString();
            cardModel.Suit = card.Suit.ToString();
            cardModel.Value = card.RankValue;

            return cardModel;
        }

        private int GetScore(List<CardView> lsit)
        {
            int score = 0;
            foreach (var value in lsit)
            {
                score += value.Value;
            }
            return score;
        }

    }
}
