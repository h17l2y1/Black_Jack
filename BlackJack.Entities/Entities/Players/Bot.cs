using Microsoft.AspNetCore.Identity;

namespace BlackJackEntities.Entities
{
    public class Bot : BaseEntity
    {
        public string Name { get; set; }
        public string BotRole { get; private set; }

        public Bot()
        {
            BotRole = "Bot";
        }
    }
}
