using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJackEntities.Entities
{
    public class Card : BaseEntity
    {
        public int CardValue { get; set; }
        public Suits Suit { get; set; }
        public Ranks Rank { get; set; }

    }
}
