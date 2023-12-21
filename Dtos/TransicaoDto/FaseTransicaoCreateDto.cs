using System.ComponentModel.DataAnnotations;

namespace SGBIMFurnas.Dtos.TransicaoDto;

public class FaseTransicaoCreateDto
{
    [Required]
    public int FaseAnteriorId { get; set; }

    [Required]
    public int FaseSeguinteId { get; set; }
}
