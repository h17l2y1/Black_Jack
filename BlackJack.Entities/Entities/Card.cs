
namespace BlackJackEntities.Entities
{
    public class Card : BaseEntity
    {
        public int Value { get; set; }
        public Suits Suit { get; set; }
        public Ranks Rank { get; set; }

    }
}
