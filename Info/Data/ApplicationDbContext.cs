using Info.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Info.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext(options)
{
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Text>? Texts { get; set; }
    public DbSet<Opinion>? Opinions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Text -> Category
        // Każdy tekst musi należeć do kategorii.
        // Nie można usunąć kategorii, do której przypisane są teksty.
        modelBuilder
            .Entity<Text>()
            .HasOne(t => t.Category)
            .WithMany(c => c.Texts)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        // Text -> AppUser
        // Autor tekstu jest opcjonalny.
        // Usunięcie użytkownika nie powoduje usunięcia jego tekstów.
        modelBuilder
            .Entity<Text>()
            .HasOne(t => t.Author)
            .WithMany(u => u.Texts)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.SetNull);
        // Opinion -> Text
        // Usunięcie tekstu powoduje usunięcie wszystkich jego opinii.
        modelBuilder
            .Entity<Opinion>()
            .HasOne(o => o.Text)
            .WithMany(t => t.Opinions)
            .HasForeignKey(o => o.TextId)
            .OnDelete(DeleteBehavior.Cascade);
        // Opinion -> AppUser
        // Usunięcie użytkownika nie powoduje usunięcia jego opinii.
        modelBuilder
            .Entity<Opinion>()
            .HasOne(o => o.Author)
            .WithMany(u => u.Opinions)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
