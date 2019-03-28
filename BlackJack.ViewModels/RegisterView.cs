using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackJackViewModels
{
    public class RegisterView
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Points")]
        public int Points { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }
    }
}
