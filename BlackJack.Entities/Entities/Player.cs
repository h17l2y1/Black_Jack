using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJackEntities.Entities
{
    [System.ComponentModel.DataAnnotations.Schema.Table("AspNetUsers")]
    public class Player : IdentityUser
    {
        public int Points { get; set; }
        public string Role { get; set; }

		[NotMapped]
        [Computed]
        public virtual ICollection<Game> Games { get; set; }
    }
}
