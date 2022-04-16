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
    public IActionResult AddProduct() => View();

    [HttpPost]
    public IActionResult CreateProduct()
    {
        string name = Request.Form["productName"];
        string tag = Request.Form["tag"];
        ProductCreationControllerHandler.CreateProduct(name, tag, _context);
        
        return Redirect("http://localhost:5000");
    }
}