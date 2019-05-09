using BlackJackEntities.Entities;
using BlackJackServices.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackServices.Services
{
	public class Deck : IDeck
	{
		protected List<Card> CardList { get; set; }

		public Deck(IEnumerable<Card> list)
		{
			CardList = new List<Card>();
			Shuffle(list);
		}

		private void Shuffle(IEnumerable<Card> list)
		{
			CardList = list.OrderBy(a => Guid.NewGuid()).ToList();
		}

		public Card GetCard()
		{
			var card = CardList.FirstOrDefault();
			RemoveCard();
			return card;
		}

		private void RemoveCard()
		{
			CardList.RemoveAt(0);
		}

		public int CardsLeft()
		{
			var cardLeft = CardList.Count;
			return cardLeft;
		}

	}
}
