using ShopManagement.DatabaseModel;

namespace ShopManagement.Controllers;

public static class DrinkRegistrationControllerHandler
{
    public static void RegisterDrink(DatabaseContext dbContext, string username, string drink)
    {
        ConsumptionRegister userRegister = new ConsumptionRegister()
        {
            Username = username,
            DrinkType = drink,
            date = DateTime.Now
        };

        dbContext.ConsumptionRegisters.Add(userRegister);
        dbContext.SaveChanges();
    }
}