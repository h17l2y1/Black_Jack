using System.Collections.Generic;

namespace BlackJackViewModels.Statistic
{
    public class ResponseGetGameStatisticView
    {
        public string GameId { get; set; }
        public List<PlayerStatisticView> Bots { get; set; }
        public PlayerStatisticView User { get; set; }
        public string Winner { get; set; }

        public ResponseGetGameStatisticView()
        {
            Bots = new List<PlayerStatisticView>();
            User = new PlayerStatisticView();
        }

    }
}
