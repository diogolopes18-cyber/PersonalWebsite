using ShopManagement.DatabaseModel;

namespace ShopManagement.CreateProject;

public static class ProductCreation
{
    private static int GetProducttIdFromDatabase(DatabaseContext context)
    {
        if (!context.ProjectDetails.Any())
            return 1;

        return context.ProjectDetails
            .Select(pd => pd.ProductId)
            .Last() + 1;
    }

    public static List<ProductDetails> DefineProject(DatabaseContext context,
        string projectName, string tag)
    {
        List<ProductDetails> project = new()
        {
            new ProductDetails
            {
                ProductId = GetProducttIdFromDatabase(context),
                Name = projectName,
                Tag = tag,
                InsertionDate = DateTime.Now
            }
        };

        return project;
    }
}