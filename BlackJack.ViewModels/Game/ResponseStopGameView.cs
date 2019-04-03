using System.Collections.Generic;

namespace BlackJackViewModels.Game
{
    public class ResponseStopGameView
    {
        public string GameId { get; set; }
        public List<PlayerGameView> Bots { get; set; }
        public PlayerGameView User { get; set; }
        public int Cardsleft { get; set; }

        public ResponseStopGameView()
        {
            Bots = new List<PlayerGameView>();
            User = new PlayerGameView();
        }
    }
}
