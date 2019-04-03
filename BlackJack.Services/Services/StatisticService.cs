﻿using BlackJackDataAccess.Repositories.Dapper.Interfaces;
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