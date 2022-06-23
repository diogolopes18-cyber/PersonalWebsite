using Microsoft.AspNetCore.Mvc;
using ShopManagement.DatabaseModel;

namespace ShopManagement.Controllers;

public class DrinkRegistrationController : Controller
{
    private readonly DatabaseContext _dbContext;
    
    public DrinkRegistrationController(DatabaseContext context)
    {
        _dbContext = context;
    }
    
    [HttpGet]
    public IActionResult ConsumptionRegister() => View();

    [HttpPost]
    public IActionResult RegisterConsumption()
    {
        string username = Request.Form["username"];
        string drink = Request.Form["drink"];
        
        //Get selected radio button
        drink = drink switch
        {
            "superbock" => "superbock",
            "somersby" => "sommersby",
            _ => drink
        };

        DrinkRegistrationControllerHandler.RegisterDrink(_dbContext, username, drink);
        Ok("Thank you for registering your drink");
        return Redirect("http://localhost:5000");
    }
}