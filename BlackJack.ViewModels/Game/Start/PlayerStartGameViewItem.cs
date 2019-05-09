using System.Collections.Generic;

namespace BlackJackViewModels.Game
{
	public class PlayerStartGameViewItem
	{
		public string Name { get; set; }
		public List<CardPlayerStartGameView> Cards { get; set; }
		public int Score { get; set; }

		public PlayerStartGameViewItem()
		{
			Cards = new List<CardPlayerStartGameView>();
		}
	}
}
