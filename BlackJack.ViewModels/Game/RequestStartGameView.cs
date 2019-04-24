using System.ComponentModel.DataAnnotations;

namespace BlackJackViewModels
{
	public class RequestStartGameView
	{
		[Required]
		public string UserId { get; set; }
		[Range(0, 5)]
		public int CountBots { get; set; }
	}
}
