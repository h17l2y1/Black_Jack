using BlackJackViewModels.Statistic;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
	public interface IStatisticService
	{
		Task<ResponseGetGameStatisticView> GetGame(string gameId, string playerId);

		Task<ResponsePaginationStatisticView> GetPagination(int page, int size);

		Task<ResponsePaginationStatisticView> GetUserStat(int page, int size, string UserName);
	}
}
