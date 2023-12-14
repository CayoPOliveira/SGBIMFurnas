using System.ComponentModel.DataAnnotations;

namespace SGBIMFurnas.Dtos.CargoDto;

public class CargoCreateDto
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(100)]
    public string? Name { get; set; }

    [Required(AllowEmptyStrings = false)]
    [MaxLength]
    public string? Permissions { get; set; }
}
