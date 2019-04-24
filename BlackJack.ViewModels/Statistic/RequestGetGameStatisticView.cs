using System.ComponentModel.DataAnnotations;

namespace BlackJackViewModels.Statistic
{
    public class RequestGetGameStatisticView
    {
		[Required]
		public string GameId { get; set; }
		[Required]
		public string PlayerId { get; set; }
    }
}
