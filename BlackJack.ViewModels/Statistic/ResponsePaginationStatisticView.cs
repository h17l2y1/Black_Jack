using System.Collections.Generic;

namespace BlackJackViewModels.Statistic
{
    public class ResponsePaginationStatisticView
    {
        public List<StatisticStatisticView> Statistics { get; set; }

        public ResponsePaginationStatisticView(List<StatisticStatisticView> list)
        {
            Statistics = list;
        }
    }
}
