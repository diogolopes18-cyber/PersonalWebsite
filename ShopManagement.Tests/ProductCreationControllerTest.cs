using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
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
        var jsonData = System.IO.File.ReadAllText(@"C:\Users\Diogo Lopes\RiderProjects\ShopManagement\ShopManagement.Tests\DatabaseSeedFiles\ProjectDetails.json");
        Seeder.Seed(jsonData, context);

        var productName = ProductCreationControllerHandler.GetProducts(context);
        Assert.NotEmpty(productName);
    }
}