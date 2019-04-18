using BlackJackViewModels.Statistic;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<ResponsePaginationStatisticView> GetPagination(int page, int size);        

        Task<ResponseGetAllGamesStatisticView> GetAllGames(string playerId);

        Task<ResponseGetGameStatisticView> GetGame(string gameId, string playerId);
    }
}
