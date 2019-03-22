using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJackEntities.Entities
{
    public class Game : BaseEntity
    {

        public virtual ICollection<CardMove> CardMoves { get; set; }

        public Game()
        {
            CardMoves = new List<CardMove>();
        }

        [NotMapped]
        public virtual ICollection<User> Users { get; set; }
    }
}
