using System.Collections.Generic;

namespace BlackJackViewModels.Game
{
    public class StartGameView
    {
        public int GameId { get; set; }
        public List<PlayerView> Bots { get; set; }
        public PlayerView User { get; set; }
        public int Cardsleft { get; set; }

        public StartGameView()
        {
            Bots = new List<PlayerView>();
            User = new PlayerView();
        }



    }
}
