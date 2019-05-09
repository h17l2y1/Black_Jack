using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJackEntities.Entities
{
    public class GameUser : BaseEntity
    {
		public string UserId { get; set; }

        [Required]
        public bool Winner { get; set; }

		[ForeignKey("UserId")]
		[Computed]
		[NotMapped]
		public Player User { get; set; }
        
        public string GameId { get; set; }

		[ForeignKey("GameId")]
		[Computed]
		[NotMapped]
		public Game Game { get; set; } 
    }
}
