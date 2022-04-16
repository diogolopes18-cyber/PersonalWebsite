using Microsoft.AspNetCore.Mvc;
using ShopManagement.DatabaseModel;

namespace ShopManagement.Controllers;

[ApiController]
[Route("[controller]")]

public class LoginController : Controller
{
    private readonly DatabaseContext _dbContext;

    public LoginController(DatabaseContext context)
    {
        _dbContext = context;
    }
    
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult UserLogin()
    {
        LoginControllerHandler.SaveUserDetails(Request.Form["username"], 
            Request.Form["password"],Request.Form["confirmedPassword"],
            Request.Form["email"], _dbContext);
        
        return Ok();
    }
}