using Microsoft.AspNetCore.Identity;

namespace BlackJackEntities.Entities
{
    public class Dialer : BaseEntity
    {
        public string Name { get; private set; }
        public string BotRole { get; private set; }

        public Dialer()
        {
            BotRole = "Dialer";
            Name = "Dialer";
        }
    }
}
