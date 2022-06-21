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

        var productName = ProductCreationControllerHandler.GetProducts(context);
        Assert.NotEmpty(productName);
    }
}