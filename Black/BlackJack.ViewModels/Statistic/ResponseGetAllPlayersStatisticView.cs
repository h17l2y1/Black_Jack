using System.Collections.Generic;

namespace BlackJackViewModels.Statistic
{
    public class ResponseGetAllPlayersStatisticView
    {
        public IEnumerable<dynamic> PlayersList { get; set; }

        public ResponseGetAllPlayersStatisticView(IEnumerable<dynamic> list)
        {
            PlayersList = list;
        }
    }
}
