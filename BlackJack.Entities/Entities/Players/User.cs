using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJackEntities.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public int UserPoints { get; set; }
        public string UserRole { get; private set; }

        public User()
        {
            UserName = "User";
        }

        [NotMapped]
        public virtual ICollection<Game> Games { get; set; }
    }
}
