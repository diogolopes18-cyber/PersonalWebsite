using ShopManagement.DatabaseModel;
using ShopManagement.CreateProject;
using System.Linq;

namespace ShopManagement.Controllers;

public static class ProductControllerHandler
{
    internal static void CreateProduct(string productName, string tag,
        DatabaseContext context)
    {
        ProductCreation product = new ProductCreation(productName, tag);
        var createdProduct = product.DefineProject(context);

        foreach (var detail in createdProduct)
        {
            context.ProjectDetails.Add(detail);
        }

        context.SaveChanges();
    }

    public static IEnumerable<ProductDetails> GetProducts(DatabaseContext context)
    {
        return context.ProjectDetails.ToList();
    }

    public static async Task<int> DeleteProduct(DatabaseContext context, int productId)
    {
        if (context.ProjectDetails.Any(x => x.ProductId == productId))
        {
            ProductDetails productToDelete = context.ProjectDetails
                .Single(p => p.ProductId == productId);

            context.ProjectDetails.Remove(productToDelete);
        }

        return await context.SaveChangesAsync();
    }
}