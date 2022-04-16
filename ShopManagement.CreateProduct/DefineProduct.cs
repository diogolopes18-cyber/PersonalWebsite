using ShopManagement.DatabaseModel;

namespace ShopManagement.CreateProject;

public class ProductCreation
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
        else
            return context.ProjectDetails
                .OrderBy(pd => pd.ProductId)
                .Select(pd => pd.ProductId)
                .Last() + 1;
    }

    public List<ProductDetails> DefineProject(DatabaseContext context)
    {
        List<ProductDetails> project = new()
        {
            new ProductDetails
            {
                ProductId = GetProductIdFromDatabase(context),
                Name = _productName,
                Tag = _tag,
                InsertionDate = DateTime.Now
            }
        };

        return project;
    }
}