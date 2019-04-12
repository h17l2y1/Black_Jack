using System.Collections.Generic;

namespace BlackJackViewModels.Game
{
    public class PlayerGameView
    {
        public string Name { get; set; }
        public List<ResponseCardGameView> Cards { get; set; }
        public int Score { get; set; }

        public PlayerGameView()
        {
            Cards = new List<ResponseCardGameView>();
        }
    }
}
