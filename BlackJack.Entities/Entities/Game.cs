using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace BlackJackEntities.Entities
{
    public class Game : BaseEntity
    {
        [Computed]
        public virtual ICollection<CardMove> CardMoves { get; set; }

        public Game()
        {
            CardMoves = new List<CardMove>();
        }

        [Computed]
        public virtual ICollection<Player> Users { get; set; }
    }
}
