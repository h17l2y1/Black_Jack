using System.Collections.Generic;

namespace BlackJackViewModels.Statistic
{
    public class GetGameStatisticViewItem
    {
        public string GameId { get; set; }
        public List<PlayerGetGameStatisticViewItem> Bots { get; set; }
        public PlayerGetGameStatisticViewItem User { get; set; }
        public string Winner { get; set; }

        public GetGameStatisticViewItem()
        {
            Bots = new List<PlayerGetGameStatisticViewItem>();
            User = new PlayerGetGameStatisticViewItem();
        }

    }
}
