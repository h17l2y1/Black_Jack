using System.Collections.Generic;

namespace BlackJackViewModels.Statistic
{
    public class PlayerStatisticView
    {
        public string Name { get; set; }
        public List<ResponseCardStatisticView> Cards { get; set; }
        public int Score { get; set; }

        public PlayerStatisticView()
        {
            Cards = new List<ResponseCardStatisticView>();
        }
    }
}
