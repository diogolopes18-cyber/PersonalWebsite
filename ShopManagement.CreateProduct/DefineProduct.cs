using ShopManagement.DatabaseModel;

namespace ShopManagement.CreateProject;

public static class ProductCreation
{
    private readonly string _productName;
    private readonly string _tag;
    public ProductCreation(string productName, string tag)
    {
        _productName = productName;
        _tag = tag;
    }
    
    private static int GetProductIdFromDatabase(DatabaseContext context)
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