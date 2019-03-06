using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJackDataAccess
{
    public class User : IdentityUser
    {
        [Required]
        [Column(TypeName = "nvarchar(100)")]

        public int UserPoints { get; set; }

    }
}
