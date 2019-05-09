using System.Collections.Generic;

namespace BlackJackViewModels.Game.Stop
{
	public class PlayerStopGameViewItem
	{
		public string Name { get; set; }
		public List<CardPlayerStopGameView> Cards { get; set; }
		public int Score { get; set; }

		public PlayerStopGameViewItem()
		{
			Cards = new List<CardPlayerStopGameView>();
		}
	}
}
