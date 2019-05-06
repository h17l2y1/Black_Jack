using BlackJackEntities.Entities;
using BlackJackEntities.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlackJackServices.Configurations
{
	public class ApplicationContext2 : IdentityDbContext<Player>
	{
		private readonly int _suitCount = 4;
		private readonly int _rankCount = 15;
		private readonly int _minTenRank = 10;
		private readonly int _maxTenRank = 14;
		private readonly int _numbersRank = 11;
		private readonly int _aceRank = 14;

		public ApplicationContext2(DbContextOptions<ApplicationContext2> options) : base(options)
		{
		}

		public string DefaultConnection { get; set; }

		public DbSet<GameUsers> GameUsers { get; set; }

		public DbSet<CardMove> CardMoves { get; set; }

		public DbSet<Game> Games { get; set; }

		public DbSet<Card> Cards { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Card>().HasData(CreateDeck().ToArray());
			builder.Entity<Player>().HasData(FirstInit().ToArray());

			base.OnModelCreating(builder);
		}

		private List<Player> FirstInit()
		{
			var playerList = new List<Player>();

			playerList.Add(new Player()
			{
				UserName = Players.Dialer.ToString(),
				Role = Players.Dialer.ToString()
			});

			for (int i = 1; i < 6; i++)
			{
				playerList.Add(new Player()
				{
					UserName = $"{Players.Bot.ToString()}_{i}",
					Role = Players.Dialer.ToString()
				});
			}
			return playerList;
		}

		private List<Card> CreateDeck()
		{
			var listCard = new List<Card>();
			for (int i = 0; i < _suitCount; i++)
			{
				for (int j = 2; j < _rankCount; j++)
				{
					listCard.Add(new Card()
					{
						Suit = (Suits)i,
						Rank = (Ranks)j
					});

					if (j < _numbersRank)
					{
						listCard[listCard.Count - 1].Value = j;
					}
					if (j >= _minTenRank && j < _maxTenRank)
					{
						listCard[listCard.Count - 1].Value = 10;
					}
					if (j == _aceRank)
					{
						listCard[listCard.Count - 1].Value = 11;
					}

				}
			}
			return listCard;
		}
	}
}
