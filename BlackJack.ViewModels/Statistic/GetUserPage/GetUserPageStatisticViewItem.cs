using System.Collections.Generic;

namespace BlackJackViewModels.Statistic.GetUserPage
{
	public class GetUserPageStatisticViewItem
	{
		public List<StatisticGetUserPageStatisticView> Page { get; set; }
		public int PageNumber { get; set; }
		public int ItemsOnPage { get; set; }
		public int TotalItems { get; set; }
		public int TotalPages { get; set; }
	}
}
