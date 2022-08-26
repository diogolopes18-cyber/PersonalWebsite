using Microsoft.AspNetCore.Mvc;
using ShopManagement.DatabaseModel;

namespace ShopManagement.Controllers;

[ApiController]
[Route("[controller]")]

public class ProductCreationController : Controller
{
    private readonly DatabaseContext _context;

    public ProductCreationController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("api/products")]
    public IEnumerable<ProductDetails> GetProducts()
    {
        return ProductCreationControllerHandler.GetProducts(_context);
    }

    [HttpGet]
    public IActionResult AddProduct() => View();

    [HttpPost]
    public IActionResult CreateProduct()
    {
        string name = Request.Form["productName"];
        string tag = Request.Form["tag"];
        ProductCreationControllerHandler.CreateProduct(name, tag, _context);
        
        return Redirect("http://localhost:5000");
    }

    [HttpDelete]
    [Route("/api/product/create")]
    public async Task<IActionResult> DeleteProduct(int productId)
    {
        return await ProductControllerHandler
            .DeleteProduct(_context, productId) != 0
            ? Ok($"Product with ID {productId} deleted")
            : BadRequest($"Product with ID {productId} deleted");
    }
}