using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UBB_SE_2024_Evil.Models;
using UBB_SE_2024_Evil.Models.Spartacus;

namespace UBB_SE_2024_Evil.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CreditCard>(card =>
            {
                card.Property(c => c.Id).ValueGeneratedOnAdd();
                card.HasKey(c => c.Id);
                card.Property(c => c.CreditCardHolder).IsRequired();
                card.Property(c => c.CreditCardNumber).IsRequired();
                card.Property(c => c.ExpirationDate).IsRequired();
                card.Property(c => c.Cvv).IsRequired();
            });

            modelBuilder.Entity<GameState>(game =>
            {
                game.Property(g => g.Id).ValueGeneratedOnAdd();
                game.HasKey(g => g.Id);
                game.Property(g => g.Level).IsRequired();
                game.Property(g => g.Name).IsRequired();
                game.Property(g => g.PlayerHealth).IsRequired();
            });
        }

        public DbSet<UBB_SE_2024_Evil.Models.CreditCard> CreditCard { get; set; } = default!;
    }
}
