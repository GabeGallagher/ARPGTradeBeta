using ARPGTradeBeta.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ARPGTradeBeta.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Item>()
                .Property(i => i.Price)
                .HasPrecision(11, 2);

            builder.Entity<Item>()
                .Property(i => i.PlayerId);

            builder.Entity<Item>()
                .HasOne(i => i.Character)
                .WithMany(c => c.EquippedItems)
                .HasForeignKey(i => i.CharacterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Character>()
                .Property(i => i.PlayerId);
        }
    }
}
