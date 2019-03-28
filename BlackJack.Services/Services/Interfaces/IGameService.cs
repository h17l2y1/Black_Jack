using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IGameService
    {
        Task<object> StartGame(string userId, int countBots);

        Task AddOneCard(string userId, string gameId);

        Task<object> Stop(string userId, string gameId);

    }
}
