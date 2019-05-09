using BlackJackEntities.Entities;
using BlackJackViewModels.Account;
using BlackJackViewModels.Game;
using BlackJackViewModels.Game.GetCard;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
	public interface IMappingService
	{
		T AccountMapper<T>(Player player, T view) where T : PlayerAccountView;

		Task<StartGameResponseViewItem> CreateStartGameModel(Player user, string gameId, List<Player> botPlayerList, int cardLeft);

		GetCardStartView StartOneCardMapper(Card card);

		Task<StopGameResponseViewItem> CreateStopGameModel(Player user, string gameId, List<Winner> winner, List<Player> botPlayerList, int cardLeft);
	}
}
