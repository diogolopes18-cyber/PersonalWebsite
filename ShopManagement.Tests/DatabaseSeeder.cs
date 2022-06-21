using System.Collections.Generic;
using System.Linq;
using JsonNet.ContractResolvers;
using Newtonsoft.Json;
using ShopManagement.DatabaseModel;

namespace ShopManagement.Tests;

public static class Seeder {
    public static void Seed(string jsonData,
        DatabaseContext context) {
        JsonSerializerSettings? settings = new JsonSerializerSettings {
            ContractResolver = new PrivateSetterContractResolver()
        };
        
        var events =
            JsonConvert.DeserializeObject<List<ProductDetails>>(
                jsonData, settings);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        if (!context.ProjectDetails.Any())
        {
            if (events != null) context.AddRange(events);
            context.SaveChanges();
        }
    }
}