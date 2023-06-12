using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogApp.Web.Entities;


public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string? Title { get; set; }

    public string? Content { get; set; }

    public List<Comment> Comments { get; set; } = new List<Comment>();

}
