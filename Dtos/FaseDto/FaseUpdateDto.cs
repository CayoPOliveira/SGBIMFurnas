using System.ComponentModel.DataAnnotations;

namespace SGBIMFurnas.Dtos.FaseDto;

public class FaseUpdateDto
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(100)]
    public string? Name { get; set; }

    [Required(AllowEmptyStrings = false)]
    [MaxLength]
    public string? Description { get; set; }

    [Required]
    public int EtapaId { get; set; }
}
