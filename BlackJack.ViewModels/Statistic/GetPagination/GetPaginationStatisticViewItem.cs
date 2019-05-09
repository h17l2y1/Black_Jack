using System.Collections.Generic;

namespace BlackJackViewModels.Statistic
{
    public class GetPaginationStatisticViewItem
    {
        public List<StatisticGetPaginationStatisticView> Page { get; set; }
        public int PageNumber { get; set; }
        public int ItemsOnPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
