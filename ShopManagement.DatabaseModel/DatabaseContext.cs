using Microsoft.EntityFrameworkCore;

namespace PersonalWebsite.DatabaseModel;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ProductDetails> ProjectDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDetails>()
            .HasKey(pd => pd.ProductId);
    }
}

public static class DbInitializer
{
    public static void Initialize(DatabaseContext context)
    {
        context.Database.Migrate();
    }
}