using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<object> GetAllPGamesFromPlayer(string playerId);

        Task<object> GetAllPlayersFromGame(string gameId);

        Task<object> GetAllMovesFromGame(string gameId);


    }
}
