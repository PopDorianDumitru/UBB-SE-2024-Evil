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
                card.Property(card => card.Id).ValueGeneratedOnAdd();
                card.HasKey(card => card.Id);
                card.Property(card => card.CreditCardHolder).IsRequired();
                card.Property(card => card.CreditCardNumber).IsRequired();
                card.Property(card => card.ExpirationDate).IsRequired();
                card.Property(card => card.Cvv).IsRequired();
            });

            modelBuilder.Entity<GameSave>(gameSave =>
            {
                gameSave.Property(gameSave => gameSave.Id).ValueGeneratedOnAdd();
                gameSave.HasKey(gameSave => gameSave.Id);
                gameSave.Property(gameSave => gameSave.Level).IsRequired();
                gameSave.Property(gameSave => gameSave.Name).IsRequired();
                gameSave.HasIndex(gameSave => gameSave.Name).IsUnique();
                gameSave.Property(gameSave => gameSave.PlayerHealth).IsRequired();
            });
        }

        public DbSet<UBB_SE_2024_Evil.Models.CreditCard> CreditCard { get; set; } = default!;
        public DbSet<UBB_SE_2024_Evil.Models.Spartacus.GameSave> GameSave { get; set; } = default!;
        public DbSet<User> UsersFromAuction { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
