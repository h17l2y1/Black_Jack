using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackViewModels.Game
{
    public class StartGameView
    {
        public List<PlayerView> Bots { get; set; }
        public PlayerView Player { get; set; }

        public StartGameView()
        {
            Bots = new List<PlayerView>();
            Player = new PlayerView();    
        }

        

    }
}
