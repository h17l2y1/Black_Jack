using BlackJackDataAccess.Repositories.Interface;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Game;
using BlackJackViewModels.Statistic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IGameUsersRepository _gameUsersRepository;
        private readonly IGameService _gameService;


        public StatisticService(IGameUsersRepository gameUsersRepository, IGameService gameService)
        {
            _gameUsersRepository = gameUsersRepository;
            _gameService = gameService;
        }

        public async Task<ResponseGetAllGamesStatisticView> GetAllGames(string playerId)
        {
            var games = _gameUsersRepository.GetAllGamesFromPlayer(playerId);
            var response = new ResponseGetAllGamesStatisticView(games);
            return response;
        }

        public async Task<ResponseGetGameStatisticView> GetGame(string gameId, string playerId)
        {
            var stopModel = _gameService.Stop(playerId, gameId);

            var gameModel = new ResponseGetGameStatisticView();
            gameModel.Cardsleft = stopModel.Result.Cardsleft;
            gameModel.GameId = stopModel.Result.GameId;
            gameModel.Winner = stopModel.Result.Winner;
            // user
            gameModel.User.Name = stopModel.Result.User.Name;
            gameModel.User.Score = stopModel.Result.User.Score;
            gameModel.User.Cards.AddRange(CardMapper(stopModel.Result.User.Cards));
            //bot
            foreach (var bot in stopModel.Result.Bots)
            {
                var newBot = new PlayerStatisticView();
                newBot.Name = bot.Name;
                newBot.Score = bot.Score;
                newBot.Cards.AddRange(CardMapper(bot.Cards));
                gameModel.Bots.Add(newBot);
            }
            return gameModel;
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

    }

}
