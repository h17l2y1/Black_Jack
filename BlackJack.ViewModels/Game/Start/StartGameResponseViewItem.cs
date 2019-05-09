using System.Collections.Generic;

namespace BlackJackViewModels.Game
{
	public class StartGameResponseViewItem
	{
		public string GameId { get; set; }
		public List<PlayerStartGameViewItem> Bots { get; set; }
		public PlayerStartGameViewItem User { get; set; }
		public int Cardsleft { get; set; }

		public StartGameResponseViewItem()
		{
			Bots = new List<PlayerStartGameViewItem>();
			User = new PlayerStartGameViewItem();
		}
	}
}
