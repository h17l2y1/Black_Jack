using System.Collections.Generic;

namespace BlackJackViewModels.Statistic
{
    public class ResponseGetAllGamesStatisticView
    {
        public IEnumerable<dynamic> GameList { get; set; }

        public ResponseGetAllGamesStatisticView(IEnumerable<dynamic> list)
        {
            GameList = list;
        }
    }
}
