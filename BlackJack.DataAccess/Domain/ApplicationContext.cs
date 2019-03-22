using BlackJackEntities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlackJackDataAccess
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameUsers> GameUsers { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<CardMove> CardMoves { get; set; }

        public DbSet<Bot> Bots { get; set; }

        public DbSet<Dialer> Dialers { get; set; }

    }
}
