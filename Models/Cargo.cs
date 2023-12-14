using System.ComponentModel.DataAnnotations;

namespace SGBIMFurnas.Models;

public class Cargo
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(100)]
    public string? Name { get; set; }

    [Required(AllowEmptyStrings = false)]
    [MaxLength]
    public string? Permissions { get; set; }

    [Required]
    public bool Valid { get; set; } = true;
}
