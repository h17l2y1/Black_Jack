using System.ComponentModel.DataAnnotations;

namespace BlackJackViewModels
{
    public class RequestSignUpAccountView
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
