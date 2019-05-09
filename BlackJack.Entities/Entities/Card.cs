
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJackEntities.Entities
{
    public class Card : BaseEntity
    {
        public int Value { get; set; }
        public SuitsType Suit { get; set; }
        public RanksType Rank { get; set; }

    }
}
