using Microsoft.EntityFrameworkCore;

namespace ShopManagement.DatabaseModel;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<ProductDetails> ProjectDetails { get; set; }
    public DbSet<UserDetails> User { get; set; }
    public DbSet<ConsumptionRegister> ConsumptionRegisters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDetails>()
            .HasKey(pd => pd.ProductId);

        modelBuilder.Entity<UserDetails>()
            .HasKey(pd => pd.Username);
        
        modelBuilder.Entity<ConsumptionRegister>()
            .HasKey(pd => pd.Username);
    }
}

public static class DbInitializer
{
    public static void Initialize(DatabaseContext context)
    {
        context.Database.Migrate();
    }
}