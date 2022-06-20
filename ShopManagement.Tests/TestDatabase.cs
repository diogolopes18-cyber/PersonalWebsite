using Microsoft.EntityFrameworkCore;
using ShopManagement.DatabaseModel;

namespace ShopManagement.Tests;

public class TestDatabaseFixture
{
    private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=ShopManagement_Test;Trusted_Connection=True";

    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public TestDatabaseFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {
                    context.Database.EnsureCreated();
                }

                _databaseInitialized = true;
            }
        }
    }

    
    public static DatabaseContext CreateContext()
        => new DatabaseContext(
            new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(ConnectionString)
                .Options);
}