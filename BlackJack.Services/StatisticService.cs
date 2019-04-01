using BlackJackDataAccess.Repositories.Dapper.Interfaces;
using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackDataAccess.Repositories.Interfaces.Dapper;
using BlackJackServices.Services.Interfaces;
using System.Threading.Tasks;

namespace BlackJackServices
{
    public class StatisticService : IStatisticService
    {
        private readonly ICardMoveRepository _cardMoveRepository;
        private readonly IGameUsersRepository _gameUsersRepository;
        private readonly IPlayerRepository _playerRepository;

        private readonly ICardMoveDapperRepository _cardMoveDapperRepository;
        private readonly IGameUsersDapperRepository _gameUsersDapperRepository;
        private readonly IPlayerDapperRepository _playerDapperRepository;

        public StatisticService(
            ICardMoveRepository cardMoveRepository, ICardMoveDapperRepository cardMoveDapperRepository,
            IGameUsersRepository gameUsersRepository, IGameUsersDapperRepository gameDapperUsersRepository,
            IPlayerRepository playerRepository, IPlayerDapperRepository playerDapperRepository
)
        {
            _cardMoveRepository = cardMoveRepository;
            _gameUsersRepository = gameUsersRepository;
            _playerRepository = playerRepository;

            _cardMoveDapperRepository = cardMoveDapperRepository;
            _gameUsersDapperRepository = gameDapperUsersRepository;
            _playerDapperRepository = playerDapperRepository;
        }

        public async Task<object> GetAllPGamesFromPlayer(string playerId)
        {
            var games = _gameUsersDapperRepository.GetAllGamesFromPlayer(playerId);
            return games;
        }

        public async Task<object> GetAllPlayersFromGame(string gameId)
        {
            var games = _gameUsersDapperRepository.GetAllPlayersFromGame(gameId);
            return games;
        }

        public async Task<object> GetAllMovesFromGame(string gameId)
        {
            var gamesMoves = _cardMoveDapperRepository.GetAllMovesFromGame(gameId);
            return gamesMoves;
        }


    }
}
