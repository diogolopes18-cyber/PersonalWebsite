using ShopManagement.DatabaseModel;
using ShopManagement.CreateProject;

namespace ShopManagement.Controllers;

internal static class ProductCreationControllerHandler
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
}