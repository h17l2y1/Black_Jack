using System.Collections.Generic;

namespace BlackJackViewModels.Statistic
{
    public class PlayerGetGameStatisticViewItem
    {
        public string Name { get; set; }
        public List<CardPlayerGetGameStatisticView> Cards { get; set; }
        public int Score { get; set; }

        public PlayerGetGameStatisticViewItem()
        {
            Cards = new List<CardPlayerGetGameStatisticView>();
        }
    }
}
