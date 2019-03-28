using BlackJackEntities.Entities;


namespace BlackJackServices.Services.Interfaces
{
    public interface IDeck
    {
        Card GetCard();

        int CardsLeft();
    }
}
