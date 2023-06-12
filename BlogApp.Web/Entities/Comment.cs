using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogApp.Web.Entities;

public class Comment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string? Text { get; set; }

    [ForeignKey("Post")]
    public int PostId { get; set; }
    [JsonIgnore]
    public Post? Post { get; set; }

}
