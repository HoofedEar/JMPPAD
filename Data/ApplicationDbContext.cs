using JMPPAD.Data.Tables;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JMPPAD.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Deck> Decks { get; set; }
    public DbSet<DeckContent> DeckContents { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<CardFace> CardFaces { get; set; }

    public DbSet<Cube> Cubes { get; set; }
    public DbSet<CubeContent> CubeContents { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityUser>().ToTable("Users");
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

        builder.Entity<Deck>()
            .HasMany(d => d.DeckContents)
            .WithMany(c => c.DeckContents)
            .UsingEntity<DeckContent>(
                j => j
                    .HasOne(cid => cid.Card)
                    .WithMany()
                    .HasForeignKey(cid => cid.CardId),
                j => j
                    .HasOne(cid => cid.Deck)
                    .WithMany()
                    .HasForeignKey(cid => cid.DeckId)
            );
    }
}