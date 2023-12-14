using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGBIMFurnas.Models;

public class Etapa
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(100)]
    public string? Name { get; set; }

    [Required(AllowEmptyStrings = false)]   
    [MaxLength]
    public string? Description { get; set; }

    [Required]
    public bool Valid { get; set; } = true;
}
