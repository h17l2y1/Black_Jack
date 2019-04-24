using System.ComponentModel.DataAnnotations;

namespace BlackJackViewModels.Requests
{
	public class RequestStopGameView
	{
		[Required]
		public string UserId { get; set; }
		[Required]
		public string GameId { get; set; }
	}
}
