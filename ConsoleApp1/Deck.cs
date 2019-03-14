using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Deck
    {

        public Deck()
        {
            var card = new Card(Card.Ranks.Five, Card.Suits.Hearts);
            var value = card.RankValueHigh;
            var aaa = card.RankValueLow;
        }
    }
}
