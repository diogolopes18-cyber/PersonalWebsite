using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagement.DatabaseModel;

public class UserDetails
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? Hash { get; set; }
    public string? Email { get; set; }
}