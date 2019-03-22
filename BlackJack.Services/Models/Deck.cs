using BlackJackEntities.Entities;
using BlackJackServices.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackServices.Services
{
    public class Deck : IDeck
    {
        public List<Card> ListOfCards { get; set; }

        public Deck()
        {
            ListOfCards = new List<Card>();
            CreateDeck();
            Shuffle();
        }

        private void CreateDeck()
        {
            foreach (Ranks rank in Enum.GetValues(typeof(Ranks)))
            {
                foreach (Suits suit in Enum.GetValues(typeof(Suits)))
                {
                    var card = new Card(rank, suit);
                    ListOfCards.Add(card);
                }
            }
        }

        private void Shuffle()
        {
            ListOfCards = ListOfCards.OrderBy(a => Guid.NewGuid()).ToList();
        }

        public Card GetCard()
        {
            var card = ListOfCards[0];
            RemoveCard();
            return card;
        }

        private void RemoveCard()
        {
            ListOfCards.RemoveAt(0);
        }

        public int CardsLeft()
        {
            var cardLeft = ListOfCards.Count;
            return cardLeft;
        }

    }
}
