using System.Collections.Generic;
using System.IO;
using System.Linq;
using ShopManagement.Controllers;
using ShopManagement.DatabaseModel;
using Xunit;

namespace ShopManagement.Tests;

public class ProductControllerTest : IClassFixture<TestDatabaseFixture>
{
    public ProductControllerTest(TestDatabaseFixture fixture)
        => Fixture = fixture;

    private TestDatabaseFixture Fixture { get; }
    
    [Fact]
    public void ProductHasName()
    {
        using DatabaseContext context = TestDatabaseFixture.CreateContext();
        string referenceFileFolderLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string jsonData = File.ReadAllText($@"{referenceFileFolderLocation}\..\DatabaseSeedFiles\ProjectDetails.json");
        Seeder.Seed(jsonData, context);

        IEnumerable<ProductDetails> productName = ProductControllerHandler.GetProducts(context);
        Assert.NotEmpty(productName);
        Assert.IsType<ProductDetails>(productName.First());
    }
}