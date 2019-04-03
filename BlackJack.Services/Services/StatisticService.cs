using BlackJackDataAccess.Repositories.Dapper.Interfaces;
using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackDataAccess.Repositories.Interfaces.Dapper;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels.Statistic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackServices
{
    public class StatisticService : IStatisticService
    {
        private readonly ICardMoveEfRepository _cardMoveRepository;
        private readonly IGameEfUsersRepository _gameUsersRepository;
        private readonly IPlayerEfRepository _playerRepository;

        private readonly ICardMoveDapperRepository _cardMoveDapperRepository;
        private readonly IGameUsersDapperRepository _gameUsersDapperRepository;
        private readonly IPlayerDapperRepository _playerDapperRepository;

        public StatisticService(
            ICardMoveEfRepository cardMoveRepository, ICardMoveDapperRepository cardMoveDapperRepository,
            IGameEfUsersRepository gameUsersRepository, IGameUsersDapperRepository gameDapperUsersRepository,
            IPlayerEfRepository playerRepository, IPlayerDapperRepository playerDapperRepository
)
        {
            _cardMoveRepository = cardMoveRepository;
            _gameUsersRepository = gameUsersRepository;
            _playerRepository = playerRepository;

            _cardMoveDapperRepository = cardMoveDapperRepository;
            _gameUsersDapperRepository = gameDapperUsersRepository;
            _playerDapperRepository = playerDapperRepository;
        }

        public async Task<ResponseGetAllGamesStatisticView> GetAllGames(string playerId)
        {
            var games = _gameUsersDapperRepository.GetAllGamesFromPlayer(playerId);
            var response = new ResponseGetAllGamesStatisticView(games);
            return response;
        }

        public async Task<ResponseGetAllPlayersStatisticView> GetAllPlayers(string gameId)
        {
            var players = _gameUsersDapperRepository.GetAllPlayersFromGame(gameId);
            var response = new ResponseGetAllPlayersStatisticView(players);
            return response;
        }

        public async Task<ResponseGetAllMovesStatisticView> GetAllMoves(string gameId)
        {
            var gamesMoves = _cardMoveDapperRepository.GetAllMovesFromGame(gameId);
            var response = new ResponseGetAllMovesStatisticView(gamesMoves);
            return response;
        }


    }
}
