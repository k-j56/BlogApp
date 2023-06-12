using System.ComponentModel.DataAnnotations;

namespace BlogApp.Web.Models;

public class AuthRequest
{
    [Required]
    public string UserName { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}

