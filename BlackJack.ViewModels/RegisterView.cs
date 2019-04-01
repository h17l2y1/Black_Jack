using System.ComponentModel.DataAnnotations;

namespace BlackJackViewModels
{
    public class RegisterView
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

    }
}
