using BlackJackViewModels.Game.Stop;
using System.Collections.Generic;

namespace BlackJackViewModels.Game
{
    public class StopGameResponseViewItem
    {
        public string GameId { get; set; }
        public List<PlayerStopGameViewItem> Bots { get; set; }
        public PlayerStopGameViewItem User { get; set; }
        public int Cardsleft { get; set; }
        public List<WinnerStopGameView> Winner { get; set; }

        public StopGameResponseViewItem()
        {
            Bots = new List<PlayerStopGameViewItem>();
            User = new PlayerStopGameViewItem();
        }
    }
}
