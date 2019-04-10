using System;

namespace BlackJackEntities.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; }

        public DateTime CreationDate { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreationDate = DateTime.UtcNow;
        }

    }
}
