﻿using Dapper.Contrib.Extensions;
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
        [Computed]
        [NotMapped]
        public virtual Game Game { get; set; }

        public string CardId { get; set; }
        [ForeignKey("CardId")]
        [Computed]
        [NotMapped]
        public virtual Card Card { get; set; }


    }
}