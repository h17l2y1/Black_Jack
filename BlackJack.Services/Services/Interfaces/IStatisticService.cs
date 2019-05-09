using BlackJackViewModels.Statistic;
using BlackJackViewModels.Statistic.GetUserPage;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
	public interface IStatisticService
	{
		Task<GetGameStatisticViewItem> GetGame(string gameId, string playerId);

		Task<GetPaginationStatisticViewItem> GetPagination(int page, int size);

		Task<GetUserPageStatisticViewItem> GetUserStat(int page, int size, string UserName);
	}
}
