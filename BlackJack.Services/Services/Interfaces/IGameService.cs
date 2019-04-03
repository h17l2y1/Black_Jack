using BlackJackViewModels.Game;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IGameService
    {
        Task<ResponseStartGameView> Start(string userId, int countBots);

        Task<ResponseCardGameView> AddOneCard(string userId, string gameId);

        Task<ResponseStopGameView> Stop(string userId, string gameId);
    }
}
