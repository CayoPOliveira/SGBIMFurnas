using System.ComponentModel.DataAnnotations;

namespace SGBIMFurnas.Dtos.EtapaDto;

public class EtapaUpdateDto
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(100)]
    public string? Name { get; set; }

    [Required(AllowEmptyStrings = false)]
    [MaxLength]
    public string? Description { get; set; }
}
