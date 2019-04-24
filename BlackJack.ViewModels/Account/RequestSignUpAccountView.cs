using System.ComponentModel.DataAnnotations;

namespace BlackJackViewModels
{
    public class RequestSignUpAccountView
    {
        [Required]
        [Display(Name = "Name")]
		[MaxLength(10)]
		public string UserName { get; set; }
    }
}
