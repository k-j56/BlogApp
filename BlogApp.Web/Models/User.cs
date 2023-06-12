using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlogApp.Web.Models;

public class User
{

    [Required]
    public string UserName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required]

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Password { get; set; }

}
