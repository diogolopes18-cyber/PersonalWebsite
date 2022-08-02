using System.IO;
using System.Linq;
using ShopManagement.Controllers;
using ShopManagement.DatabaseModel;
using Xunit;

namespace ShopManagement.Tests;

public class ProductCreationControllerTest : IClassFixture<TestDatabaseFixture>
{
    public ProductCreationControllerTest(TestDatabaseFixture fixture)
        => Fixture = fixture;

    private TestDatabaseFixture Fixture { get; }
    
    [Fact]
    public void ProductHasName()
    {
        using DatabaseContext context = TestDatabaseFixture.CreateContext();
        string referenceFileFolderLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string jsonData = File.ReadAllText($@"{referenceFileFolderLocation}\..\DatabaseSeedFiles\ProjectDetails.json");
        Seeder.Seed(jsonData, context);

        var productName = ProductCreationControllerHandler.GetProducts(context);
        Assert.NotEmpty(productName);
        Assert.IsType<ProductDetails>(productName.First());
    }
}