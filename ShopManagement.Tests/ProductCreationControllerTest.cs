using System;
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
        ProductDetails product = new ProductDetails()
        {
            InsertionDate = DateTime.Now,
            Name = "PF-Test",
            ProductId = 23,
            Tag = "3289329"
        };

        context.ProjectDetails.Add(product);
        context.SaveChanges();

        var productName = ProductCreationControllerHandler.GetProducts(context);
        Assert.NotEmpty(productName);
    }
}