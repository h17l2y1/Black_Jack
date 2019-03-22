using BlackJackViewModels.Game;
using System;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IGameService
    {
        Task<object> StartGame(string userId, int countBots);

        CardView GetCardView();

    }
}
