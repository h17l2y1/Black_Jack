using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackJackViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Points")]
        public int UserPoints { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string UserRole { get; set; }
    }
}
