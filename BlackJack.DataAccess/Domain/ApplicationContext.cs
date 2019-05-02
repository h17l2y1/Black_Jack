using BlackJackEntities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlackJackDataAccess
{
    public class ApplicationContext : IdentityDbContext<Player>
    {
		private readonly int suitCount = 4;
		private readonly int rankCount = 15;
		private readonly int minTenRank = 10;
		private readonly int maxTenRank = 14;
		private readonly int numbersRank = 11;
		private readonly int aceRank = 14;

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
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
                UserName = "Dialer",
                Role = "Bot"
            });

            for (int i = 1; i < 6; i++)
            {
                playerList.Add(new Player()
                {
                    UserName = $"Bot_{i}",
                    Role = "Bot"
                });
            }
            return playerList;
        }

        private List<Card> CreateDeck()
        {
            var listCard = new List<Card>();
            for (int i = 0; i < suitCount; i++)
            {
                for (int j = 2; j < rankCount; j++)
                {
                    listCard.Add(new Card()
                    {
                        Suit = (Suits)i,
                        Rank = (Ranks)j
                    });

                    if (j < numbersRank)
                    {
                        listCard[listCard.Count - 1].Value = j;
                    }
                    if (j >= minTenRank && j < maxTenRank)
                    {
                        listCard[listCard.Count - 1].Value = 10;
                    }
                    if (j == aceRank)
                    {
                        listCard[listCard.Count - 1].Value = 11;
                    }

                }
            }
            return listCard;
        }
    }
}
