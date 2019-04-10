using BlackJackDataAccess.Repositories.Interface;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Statistic;
using System.Threading.Tasks;

namespace BlackJackServices
{
    public class StatisticService : IStatisticService
    {
        private readonly ICardMoveRepository _cardMoveRepository;
        private readonly IGameUsersRepository _gameUsersRepository;

        public StatisticService(ICardMoveRepository cardMoveRepository, IGameUsersRepository gameUsersRepository)
        {
            _cardMoveRepository = cardMoveRepository;
            _gameUsersRepository = gameUsersRepository;
        }

        public async Task<ResponseGetAllGamesStatisticView> GetAllGames(string playerId)
        {
            var games = _gameUsersRepository.GetAllGamesFromPlayer(playerId);
            var response = new ResponseGetAllGamesStatisticView(games);
            return response;
        }

        public async Task<ResponseGetAllPlayersStatisticView> GetAllPlayers(string gameId)
        {
            var players = _gameUsersRepository.GetAllPlayersFromGame(gameId);
            var response = new ResponseGetAllPlayersStatisticView(players);
            return response;
        }

        public async Task<ResponseGetAllMovesStatisticView> GetAllMoves(string gameId)
        {
            var gamesMoves = _cardMoveRepository.GetAllMovesFromGame(gameId);
            var response = new ResponseGetAllMovesStatisticView(gamesMoves);
            return response;
        }
    }

}
