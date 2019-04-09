using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJackEntities.Entities
{
    public class CardMove : BaseEntity
    {
        public int Move { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string PlayerId { get; set; }

        public string GameId { get; set; }
        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }

        public string CardId { get; set; }
        [ForeignKey("CardId")]
        public virtual Card Card { get; set; }


    }
}