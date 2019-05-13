using BlackJackEntities.Entities;
using BlackJackEntities.Enums;
using System.Collections.Generic;

namespace BlackJackDataAccess.Domain
{
	public class AutoComplete
	{
		public List<Player> FirstInit()
		{
			var playerList = new List<Player>();

			playerList.Add(new Player()
			{
				UserName = PlayersType.Dialer.ToString(),
				Role = PlayersType.Dialer.ToString()
			});

			for (int i = 1; i < (int)DeckConfigType.botsCount; i++)
			{
				playerList.Add(new Player()
				{
					UserName = $"{PlayersType.Bot.ToString()}_{i}",
					Role = PlayersType.Bot.ToString()
				});
			}
			return playerList;
		}

		public List<Card> CreateDeck()
		{
			var listCard = new List<Card>();
			for (int i = 0; i < (int)DeckConfigType.suitCount; i++)
			{
				for (int j = (int)DeckConfigType.fromCard; j < (int)DeckConfigType.rankCount; j++)
				{
					listCard.Add(new Card()
					{
						Suit = (SuitsType)i,
						Rank = (RanksType)j
					});

					if (j < (int)DeckConfigType.numbersRank)
					{
						listCard[listCard.Count - 1].Value = j;
					}
					if (j >= (int)DeckConfigType.minTenRank && j < (int)DeckConfigType.maxTenRank)
					{
						listCard[listCard.Count - 1].Value = (int)DeckConfigType.minTenRank;
					}
					if (j == (int)DeckConfigType.aceRank)
					{
						listCard[listCard.Count - 1].Value = (int)DeckConfigType.numbersRank;
					}
				}
			}
			return listCard;
		}
	}
}
