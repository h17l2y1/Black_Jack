using BlackJackEntities.Entities;

namespace BlackJackServices
{
    public class Card
    {
        public Ranks Rank { get; set; }
        public Suits Suit { get; set; }

        public Card(Ranks rankValue, Suits suit)
        {
            Rank = rankValue;
            Suit = suit;
        }

        public int RankValue
        {
            get
            {
                switch (Rank)
                {
                    case Ranks.Ace:
                        return 11;

                    case Ranks.King:
                    case Ranks.Queen:
                    case Ranks.Jack:
                    case Ranks.Ten:
                        return 10;

                    default:
                        return (int)Rank;
                }
            }
        }

    }

}

