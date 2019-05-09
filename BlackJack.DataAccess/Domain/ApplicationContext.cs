using BlackJackDataAccess.Domain;
using BlackJackEntities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlackJackDataAccess
{
	public class ApplicationContext : IdentityDbContext<Player>
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}

		//public string DefaultConnection { get; set; }

		public DbSet<GameUser> GameUsers { get; set; }

		public DbSet<CardMove> CardMoves { get; set; }

		public DbSet<Game> Games { get; set; }

		public DbSet<Card> Cards { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			var init = new AutoComplete();

			builder.Entity<Card>().HasData(init.CreateDeck().ToArray());
			builder.Entity<Player>().HasData(init.FirstInit().ToArray());

			base.OnModelCreating(builder);
		}

	}
}
