using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Game;
using BlackJackViewModels.Statistic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IGameService _gameService;
        private readonly IGameUsersRepository _gameUsersRepository;
        private readonly IStatisticRepository _statisticRepository;

        public StatisticService(IGameUsersRepository gameUsersRepository, IGameService gameService, IStatisticRepository statisticRepository)
        {
            _gameService = gameService;
            _gameUsersRepository = gameUsersRepository;
            _statisticRepository = statisticRepository;
        }

        public async Task<ResponsePaginationStatisticView> GetPagination(int from)
        {
            var games = _statisticRepository.GetAllGames(from);
            var model = await GamesMapper(games);
            return model;
        }

        //private Test Index(int page = 1)
        //{
        //    int pageSize = 3; 
        //    IEnumerable<Phone> phonesPerPages = phones.Skip((page - 1) * pageSize).Take(pageSize);

        //    var pageInfo = new PageInfo {
        //        PageNumber = page,
        //        PageSize = pageSize,
        //        TotalItems = phones.Count
        //    };

        //    var ivm = new IndexViewModel {
        //        PageInfo = pageInfo,
        //        Phones = phonesPerPages
        //    };
        //    return ivm;
        //}

        private async Task<ResponsePaginationStatisticView> GamesMapper(List<Statistic> games)
        {
            var list = new List<StatisticStatisticView>();
            foreach (var item in games)
            {
                var game = new StatisticStatisticView
                {
                    GameId = item.GameId,
                    Score = item.Score,
                    UserName = item.UserName,
                    Winner = item.Winner
                };
                list.Add(game);
            }
            var model = new ResponsePaginationStatisticView(list);
            return model;
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
