using System.ComponentModel.DataAnnotations;

namespace BlackJackViewModels
{
    public class RequestSignUpAccountView
    {
        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }
    }
}
