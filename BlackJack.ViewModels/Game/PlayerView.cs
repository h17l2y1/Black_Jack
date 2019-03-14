using System.Collections.Generic;

namespace BlackJackViewModels.Game
{
    public class PlayerView
    {
        public string Name { get; set; }
        public List<CardView> Cards { get; set; }
        public int Score { get; set; }

        public PlayerView()
        {
            Cards = new List<CardView>();
        }

    }
}
