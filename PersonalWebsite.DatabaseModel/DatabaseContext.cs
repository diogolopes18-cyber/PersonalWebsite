using Microsoft.EntityFrameworkCore;

namespace PersonalWebsite.DatabaseModel;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options) {}
    
    public DbSet<ProjectDetails> ProjectDetails { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectDetails>()
            .HasKey(pd => pd.ProjectId);
    }
}

public static class DbInitializer
{
    public static void Initialize(DatabaseContext context)
    {
        context.Database.Migrate();
    }
}