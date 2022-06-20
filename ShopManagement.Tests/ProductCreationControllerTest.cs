using ShopManagement.Controllers;
using ShopManagement.DatabaseModel;
using Xunit;

namespace ShopManagement.Tests;

public class ProductCreationControllerTest : IClassFixture<TestDatabaseFixture>
{
    public ProductCreationControllerTest(TestDatabaseFixture fixture)
        => Fixture = fixture;

    public TestDatabaseFixture Fixture { get; }
    
    [Fact]
    public void ProductHasName()
    {
        using DatabaseContext context = TestDatabaseFixture.CreateContext();
        var controller = new ProductCreationController(context);

        var productName = controller.GetProducts();
        Assert.NotEmpty(productName);
    }
}