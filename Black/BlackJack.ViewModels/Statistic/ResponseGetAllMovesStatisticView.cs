using System.Collections.Generic;

namespace BlackJackViewModels.Statistic
{
    public class ResponseGetAllMovesStatisticView
    {
        public IEnumerable<dynamic> MovesList { get; set; }

        public ResponseGetAllMovesStatisticView(IEnumerable<dynamic> list)
        {
            MovesList = list;
        }
    }
}
