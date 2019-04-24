using System.ComponentModel.DataAnnotations;

namespace BlackJackViewModels.Statistic
{
    public class RequestPaginationStatisticView
    {
		[Required]
		public int Page { get; set; }

		[Required]
		[Range(0, 5)]
		public int Size { get; set; }
    }
}
