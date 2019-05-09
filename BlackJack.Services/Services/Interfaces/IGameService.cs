using BlackJackViewModels.Game;
using BlackJackViewModels.Game.GetCard;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IGameService
    {
        Task<StartGameResponseViewItem> Start(string userId, int countBots);

        Task<GetCardStartView> AddOneCard(string userId, string gameId);

        Task<StopGameResponseViewItem> Stop(string userId, string gameId);
    }
}
