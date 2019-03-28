using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJackEntities.Entities
{
    public class GameUsers : BaseEntity
    {
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public Player User { get; set; }
        
        public string GameId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }
    }
}
