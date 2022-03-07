using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagement.DatabaseModel;

public class ProductDetails
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public DateTime InsertionDate { get; set; }
}