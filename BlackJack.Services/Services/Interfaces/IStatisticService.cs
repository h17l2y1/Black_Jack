using BlackJackViewModels.Statistic;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<ResponseGetAllGamesStatisticView> GetAllGames(string gameId);

        Task<ResponseGetAllPlayersStatisticView> GetAllPlayers(string UserId);

        Task<ResponseGetAllMovesStatisticView> GetAllMoves(string UserId);
    }
}
